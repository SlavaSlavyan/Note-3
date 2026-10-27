using Cinema.Configuration;
using Cinema.Infrastructure;
using Cinema.Services;
using Cinema.UI;
using Npgsql;

namespace Cinema
{
    internal static class Program
    {
        // изначально вообще точка входа не должна быть асинхронной, но вот таким образом оказывается может
        public static async Task<int> Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            DbConnectionFactory factory;
            try
            {
                factory = new DbConnectionFactory(AppConfig.GetConnectionString());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка конфигурации: {ex.Message}");
                return 1;
            }

            if (!await TestConnectionAsync(factory))
            {
                return 1;
            }

            var menu = new Menu(
                new FilmService(factory),
                new ScreeningService(factory),
                new CustomerService(factory),
                new TicketService(factory),
                new ReportService(factory));

            await menu.RunAsync();
            return 0;
        }

        /// <summary>
        /// Проверяет, что соединение с БД открывается и простой запрос выполняется.
        /// </summary>
        private static async Task<bool> TestConnectionAsync(DbConnectionFactory factory)
        {
            try
            {
                await using var conn = await factory.OpenAsync();
                await using var cmd = new NpgsqlCommand("SELECT CURRENT_TIMESTAMP", conn);
                var result = await cmd.ExecuteScalarAsync();
                Console.WriteLine($"Подключение к БД установлено. Время сервера: {result}");
                return true;
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine($"Не удалось подключиться к PostgreSQL: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Неожиданная ошибка при подключении: {ex.Message}");
                return false;
            }
        }
    }
}
