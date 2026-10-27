using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.Configuration
{
    internal static class AppConfig
    {
        private const string EnvVarName = "CINEMA_DB_CONNECTION";
        private static string? _cached;

        /// <summary>
        /// Возвращает строку подключения из переменной окружения
        /// или запрашивает её интерактивно (результат кэшируется).
        /// </summary>
        public static string GetConnectionString()
        {
            if (_cached is not null) return _cached;

            var fromEnv = Environment.GetEnvironmentVariable(EnvVarName);
            if (!string.IsNullOrWhiteSpace(fromEnv))
            {
                _cached = fromEnv.Trim();
                return _cached;
            }

            Console.Write($"Переменная {EnvVarName} не задана. Введите строку подключения: ");
            var input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new InvalidOperationException(
                    $"Строка подключения не задана. Установите {EnvVarName} или введите её при запуске.");
            }
            _cached = input.Trim();
            return _cached;
        }
    }
}
