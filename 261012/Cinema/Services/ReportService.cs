using Cinema.Infrastructure;
using Cinema.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.Services
{
    internal sealed class ReportService
    {
        private readonly DbConnectionFactory _factory;

        public ReportService(DbConnectionFactory factory) => _factory = factory;

        /// <summary>
        /// Отчёт по всем сеансам: число проданных билетов и выручка.
        /// Сеансы без продаж попадают в отчёт с нулями.
        /// </summary>
        public async Task<List<ScreeningReport>> GetScreeningReportAsync()
        {
            const string sql = @"
            SELECT s.screening_id,
                   f.title,
                   s.starts_at,
                   h.hall_name,
                   COUNT(t.ticket_id) FILTER (WHERE t.status = 'Purchased') AS sold_tickets,
                   COALESCE(SUM(s.ticket_price) FILTER (WHERE t.status = 'Purchased'), 0) AS revenue
            FROM screenings s
            JOIN films  f ON f.film_id = s.film_id
            JOIN halls  h ON h.hall_id = s.hall_id
            LEFT JOIN tickets t ON t.screening_id = s.screening_id
            GROUP BY s.screening_id, f.title, s.starts_at, h.hall_name, s.ticket_price
            ORDER BY s.starts_at";

            var list = new List<ScreeningReport>();
            await using var conn = await _factory.OpenAsync();
            await using var cmd = new NpgsqlCommand(sql, conn);
            await using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                list.Add(new ScreeningReport
                {
                    ScreeningId = reader.GetInt32(0),
                    FilmTitle = reader.GetString(1),
                    StartsAt = reader.GetDateTime(2),
                    HallName = reader.GetString(3),
                    SoldTickets = reader.GetInt32(4),
                    Revenue = reader.GetDecimal(5)
                });
            }
            return list;
        }

        /// <summary>
        /// Топ фильмов по количеству проданных (Purchased) билетов.
        /// </summary>
        public async Task<List<FilmTop>> GetTopFilmsAsync(int limit = 3)
        {
            const string sql = @"
            SELECT f.title, COUNT(t.ticket_id) AS tickets_sold
            FROM films f
            JOIN screenings s ON s.film_id = f.film_id
            JOIN tickets  t ON t.screening_id = s.screening_id AND t.status = 'Purchased'
            GROUP BY f.film_id, f.title
            ORDER BY tickets_sold DESC, f.title
            LIMIT @lim";

            var list = new List<FilmTop>();
            await using var conn = await _factory.OpenAsync();
            await using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("lim", limit);

            await using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                list.Add(new FilmTop
                {
                    Title = reader.GetString(0),
                    TicketsSold = reader.GetInt32(1)
                });
            }
            return list;
        }
    }
}
