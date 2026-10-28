using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessEf.UI
{
    internal static class ConsoleHelper
    {
        public static string ReadRequired(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                var value = Console.ReadLine()?.Trim();
                if (!string.IsNullOrWhiteSpace(value)) return value;
                Console.WriteLine("Значение обязательно.");
            }
        }

        public static string? ReadOptional(string prompt)
        {
            Console.Write(prompt);
            var value = Console.ReadLine()?.Trim();
            return string.IsNullOrWhiteSpace(value) ? null : value;
        }

        public static int ReadPositiveInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int value) && value > 0)
                    return value;
                Console.WriteLine("Введите положительное целое число.");
            }
        }

        public static DateOnly ReadDate(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                var input = Console.ReadLine()?.Trim();
                if (DateOnly.TryParse(input, out var date)) return date;
                Console.WriteLine("Введите дату в формате ГГГГ-ММ-ДД.");
            }
        }
    }
}
