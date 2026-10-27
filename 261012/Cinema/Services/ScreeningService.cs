using Cinema.Infrastructure;
using Cinema.Models;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.Services
{
    internal sealed class ScreeningService
    {
        private readonly DbConnectionFactory _factory;

        public ScreeningService(DbConnectionFactory factory) => _factory = factory;

        /// <summary>
        /// Возвращает расписание сеансов с подсчётом свободных мест.
        /// Диапазон дат опционален.
        /// </summary>
        public async Task<List<ScreeningInfo>> GetScheduleAsync(DateTime? from, DateTime? to)
        {
            const string sql = @"
            SELECT s.screening_id,
                   f.title,
                   f.genre,
                   s.starts_at,
                   h.hall_name,
                   s.ticket_price,
                   h.seat_count,
                   h.seat_count - COUNT(t.ticket_id) FILTER (WHERE t.status = 'Purchased') AS free_seats
            FROM screenings s
            JOIN films  f ON f.film_id = s.film_id
            JOIN halls  h ON h.hall_id = s.hall_id
            LEFT JOIN tickets t ON t.screening_id = s.screening_id
            WHERE (@from_date IS NULL OR s.starts_at >= @from_date)
              AND (@to_date   IS NULL OR s.starts_at <  @to_date)
            GROUP BY s.screening_id, f.title, f.genre, s.starts_at, h.hall_name, s.ticket_price, h.seat_count
            ORDER BY s.starts_at";

            var list = new List<ScreeningInfo>();
            await using var conn = await _factory.OpenAsync();
            await using var cmd = new NpgsqlCommand(sql, conn);

            var pFrom = cmd.Parameters.Add("from_date", NpgsqlDbType.Timestamp);
            pFrom.Value = (object?)from ?? DBNull.Value;

            var pTo = cmd.Parameters.Add("to_date", NpgsqlDbType.Timestamp);
            pTo.Value = (object?)to ?? DBNull.Value;

            await using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                list.Add(new ScreeningInfo
                {
                    ScreeningId = reader.GetInt32(0),
                    FilmTitle = reader.GetString(1),
                    Genre = reader.GetString(2),
                    StartsAt = reader.GetDateTime(3),
                    HallName = reader.GetString(4),
                    TicketPrice = reader.GetDecimal(5),
                    TotalSeats = reader.GetInt32(6),
                    FreeSeats = reader.GetInt32(7)
                });
            }
            return list;
        }
    }
}
