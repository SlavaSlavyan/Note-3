using Cinema.Infrastructure;
using Cinema.Results;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.Services
{
    internal sealed class TicketService
    {
        private readonly DbConnectionFactory _factory;

        public TicketService(DbConnectionFactory factory) => _factory = factory;

        /// <summary>
        /// Оформляет покупку билета. Все проверки и вставка выполняются в одной транзакции.
        /// Уникальный индекс БД защищает от гонки при одновременной покупке одного места.
        /// </summary>
        public async Task<PurchaseResult> PurchaseAsync(int screeningId, int customerId, int seatNumber)
        {
            await using var conn = await _factory.OpenAsync();
            await using var tx = await conn.BeginTransactionAsync();

            try
            {
                // 1. Сеанс существует?
                var screening = await GetScreeningForPurchaseAsync(conn, tx, screeningId);
                if (screening is null)
                {
                    await tx.RollbackAsync();
                    return PurchaseResult.Error($"Сеанс с id={screeningId} не найден.");
                }

                // 2. Клиент существует?
                if (!await CustomerExistsAsync(conn, tx, customerId))
                {
                    await tx.RollbackAsync();
                    return PurchaseResult.Error($"Клиент с id={customerId} не найден.");
                }

                // 3. Место с таким номером существует в зале сеанса?
                var seatId = await FindSeatIdAsync(conn, tx, screening.HallId, seatNumber);
                if (seatId is null)
                {
                    await tx.RollbackAsync();
                    return PurchaseResult.Error(
                        $"Место №{seatNumber} не найдено в зале сеанса {screeningId}.");
                }

                // 4. Место свободно?
                if (await IsSeatTakenAsync(conn, tx, screeningId, seatId.Value))
                {
                    await tx.RollbackAsync();
                    return PurchaseResult.Error($"Место №{seatNumber} уже занято на этом сеансе.");
                }

                // 5. Вставка. Уникальный индекс БД может отклонить гонку.
                int ticketId;
                try
                {
                    ticketId = await InsertTicketAsync(
                        conn, tx, screeningId, screening.HallId, seatId.Value, customerId);
                }
                catch (PostgresException ex) when (ex.SqlState == "23505")
                {
                    await tx.RollbackAsync();
                    return PurchaseResult.Error(
                        "Место уже занято (конфликт одновременной покупки). Попробуйте другое место.");
                }

                await tx.CommitAsync();
                return PurchaseResult.Success(
                    ticketId, screening.FilmTitle, screening.StartsAt, seatNumber, screening.Price);
            }
            catch
            {
                try { await tx.RollbackAsync(); } catch { /* ignore */ }
                throw;
            }
        }

        /// <summary>
        /// Отменяет действующий билет (статус Cancelled). Строка из БД не удаляется.
        /// </summary>
        public async Task<CancelResult> CancelAsync(int ticketId)
        {
            await using var conn = await _factory.OpenAsync();

            if (!await TicketExistsAsync(conn, ticketId))
                return CancelResult.NotFound();

            const string sql = @"
            UPDATE tickets
            SET status = 'Cancelled'
            WHERE ticket_id = @id AND status = 'Purchased'";

            await using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("id", ticketId);

            var affected = await cmd.ExecuteNonQueryAsync();
            return affected == 0 ? CancelResult.AlreadyCancelled() : CancelResult.Success();
        }

        // ---------- вспомогательные запросы ----------

        private sealed record ScreeningPurchaseInfo(
            int ScreeningId, int HallId, decimal Price, DateTime StartsAt, string FilmTitle);

        private static async Task<ScreeningPurchaseInfo?> GetScreeningForPurchaseAsync(
            NpgsqlConnection conn, NpgsqlTransaction tx, int screeningId)
        {
            const string sql = @"
            SELECT s.screening_id, s.hall_id, s.ticket_price, s.starts_at, f.title
            FROM screenings s
            JOIN films f ON f.film_id = s.film_id
            WHERE s.screening_id = @id";

            await using var cmd = new NpgsqlCommand(sql, conn, tx);
            cmd.Parameters.AddWithValue("id", screeningId);

            await using var reader = await cmd.ExecuteReaderAsync();
            if (!await reader.ReadAsync()) return null;

            return new ScreeningPurchaseInfo(
                reader.GetInt32(0), reader.GetInt32(1), reader.GetDecimal(2),
                reader.GetDateTime(3), reader.GetString(4));
        }

        private static async Task<bool> CustomerExistsAsync(
            NpgsqlConnection conn, NpgsqlTransaction tx, int customerId)
        {
            await using var cmd = new NpgsqlCommand(
                "SELECT 1 FROM customers WHERE customer_id = @id", conn, tx);
            cmd.Parameters.AddWithValue("id", customerId);
            return await cmd.ExecuteScalarAsync() is not null;
        }

        private static async Task<int?> FindSeatIdAsync(
            NpgsqlConnection conn, NpgsqlTransaction tx, int hallId, int seatNumber)
        {
            await using var cmd = new NpgsqlCommand(
                "SELECT seat_id FROM seats WHERE hall_id = @h AND seat_number = @n", conn, tx);
            cmd.Parameters.AddWithValue("h", hallId);
            cmd.Parameters.AddWithValue("n", seatNumber);
            var result = await cmd.ExecuteScalarAsync();
            return result is int i ? i : null;
        }

        private static async Task<bool> IsSeatTakenAsync(
            NpgsqlConnection conn, NpgsqlTransaction tx, int screeningId, int seatId)
        {
            await using var cmd = new NpgsqlCommand(@"
            SELECT 1 FROM tickets
            WHERE screening_id = @s AND seat_id = @st AND status = 'Purchased'
            LIMIT 1", conn, tx);
            cmd.Parameters.AddWithValue("s", screeningId);
            cmd.Parameters.AddWithValue("st", seatId);
            return await cmd.ExecuteScalarAsync() is not null;
        }

        private static async Task<int> InsertTicketAsync(
            NpgsqlConnection conn, NpgsqlTransaction tx,
            int screeningId, int hallId, int seatId, int customerId)
        {
            const string sql = @"
            INSERT INTO tickets (screening_id, hall_id, seat_id, customer_id, status)
            VALUES (@s, @h, @st, @c, 'Purchased')
            RETURNING ticket_id";

            await using var cmd = new NpgsqlCommand(sql, conn, tx);
            cmd.Parameters.AddWithValue("s", screeningId);
            cmd.Parameters.AddWithValue("h", hallId);
            cmd.Parameters.AddWithValue("st", seatId);
            cmd.Parameters.AddWithValue("c", customerId);

            var result = await cmd.ExecuteScalarAsync();
            return Convert.ToInt32(result);
        }

        private static async Task<bool> TicketExistsAsync(NpgsqlConnection conn, int ticketId)
        {
            await using var cmd = new NpgsqlCommand(
                "SELECT 1 FROM tickets WHERE ticket_id = @id", conn);
            cmd.Parameters.AddWithValue("id", ticketId);
            return await cmd.ExecuteScalarAsync() is not null;
        }
    }
}
