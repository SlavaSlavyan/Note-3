using Cinema.Infrastructure;
using Cinema.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.Services
{
    internal sealed class CustomerService
    {
        private readonly DbConnectionFactory _factory;

        public CustomerService(DbConnectionFactory factory) => _factory = factory;

        public async Task<Customer?> FindByEmailAsync(string email)
        {
            const string sql = @"
            SELECT customer_id, first_name, last_name, email, phone, registered_at
            FROM customers
            WHERE email = @email";

            await using var conn = await _factory.OpenAsync();
            await using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("email", email);

            await using var reader = await cmd.ExecuteReaderAsync();
            if (!await reader.ReadAsync()) return null;

            return new Customer
            {
                CustomerId = reader.GetInt32(0),
                FirstName = reader.GetString(1),
                LastName = reader.GetString(2),
                Email = reader.GetString(3),
                Phone = reader.IsDBNull(4) ? null : reader.GetString(4),
                RegisteredAt = reader.GetDateTime(5)
            };
        }

        public async Task<List<CustomerTicket>> GetTicketsAsync(int customerId)
        {
            const string sql = @"
            SELECT t.ticket_id, f.title, s.starts_at, h.hall_name,
                   st.seat_number, s.ticket_price, t.status
            FROM tickets t
            JOIN screenings s ON s.screening_id = t.screening_id
            JOIN films      f ON f.film_id = s.film_id
            JOIN halls      h ON h.hall_id = s.hall_id
            JOIN seats     st ON st.seat_id = t.seat_id
            WHERE t.customer_id = @cid
            ORDER BY s.starts_at, st.seat_number";

            var list = new List<CustomerTicket>();
            await using var conn = await _factory.OpenAsync();
            await using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("cid", customerId);

            await using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                list.Add(new CustomerTicket
                {
                    TicketId = reader.GetInt32(0),
                    FilmTitle = reader.GetString(1),
                    StartsAt = reader.GetDateTime(2),
                    HallName = reader.GetString(3),
                    SeatNumber = reader.GetInt32(4),
                    Price = reader.GetDecimal(5),
                    Status = reader.GetString(6)
                });
            }
            return list;
        }

        /// <summary>
        /// Регистрирует клиента. Возвращает новый customer_id.
        /// Бросает InvalidOperationException, если email уже используется.
        /// </summary>
        public async Task<int> RegisterAsync(string firstName, string lastName, string email, string? phone)
        {
            const string sql = @"
            INSERT INTO customers (first_name, last_name, email, phone)
            VALUES (@fn, @ln, @em, @ph)
            RETURNING customer_id";

            await using var conn = await _factory.OpenAsync();
            await using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("fn", firstName);
            cmd.Parameters.AddWithValue("ln", lastName);
            cmd.Parameters.AddWithValue("em", email);
            cmd.Parameters.AddWithValue("ph", (object?)phone ?? DBNull.Value);

            try
            {
                var result = await cmd.ExecuteScalarAsync();
                return Convert.ToInt32(result);
            }
            catch (PostgresException ex) when (ex.SqlState == "23505")
            {
                throw new InvalidOperationException($"Клиент с email '{email}' уже существует.");
            }
        }
    }
}
