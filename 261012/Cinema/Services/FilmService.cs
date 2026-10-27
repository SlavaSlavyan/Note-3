using Cinema.Infrastructure;
using Cinema.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;

namespace Cinema.Services
{
    internal sealed class FilmService
    {
        private readonly DbConnectionFactory _factory;

        public FilmService(DbConnectionFactory factory) => _factory = factory;

        public async Task<List<Film>> GetAllAsync()
        {
            const string sql = @"
            SELECT film_id, title, genre, duration_minutes, age_rating, release_year, description
            FROM films
            ORDER BY title";

            var films = new List<Film>();
            await using var conn = await _factory.OpenAsync();
            await using var cmd = new NpgsqlCommand(sql, conn);
            await using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
                films.Add(Map(reader));

            return films;
        }

        public async Task<List<Film>> SearchByTitleAsync(string query)
        {
            const string sql = @"
            SELECT film_id, title, genre, duration_minutes, age_rating, release_year, description
            FROM films
            WHERE title ILIKE @q
            ORDER BY title";

            var films = new List<Film>();
            await using var conn = await _factory.OpenAsync();
            await using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("q", $"%{query}%");

            await using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
                films.Add(Map(reader));

            return films;
        }

        private static Film Map(NpgsqlDataReader r) => new()
        {
            FilmId = r.GetInt32(0),
            Title = r.GetString(1),
            Genre = r.GetString(2),
            DurationMinutes = r.GetInt32(3),
            AgeRating = r.GetInt32(4),
            ReleaseYear = r.GetInt32(5),
            Description = r.IsDBNull(6) ? null : r.GetString(6)
        };
    }
}
