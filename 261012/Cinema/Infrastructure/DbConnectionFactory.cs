using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;

namespace Cinema.Infrastructure
{
    internal sealed class DbConnectionFactory
    {
        private readonly string _connectionString;

        public DbConnectionFactory(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException("Строка подключения не может быть пустой", nameof(connectionString));
            _connectionString = connectionString;
        }

        public async Task<NpgsqlConnection> OpenAsync(CancellationToken ct = default)
        {
            var conn = new NpgsqlConnection(_connectionString);
            try
            {
                await conn.OpenAsync(ct);
                return conn;
            }
            catch
            {
                await conn.DisposeAsync();
                throw;
            }
        }
    }
}
