using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Cinema.UI
{
    internal static class ConsoleHelper
    {
        public static string ReadNonEmptyString(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                var s = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(s)) return s.Trim();
                Console.WriteLine("  Поле не может быть пустым.");
            }
        }

        public static string? ReadOptionalString(string prompt)
        {
            Console.Write(prompt);
            var s = Console.ReadLine();
            return string.IsNullOrWhiteSpace(s) ? null : s.Trim();
        }

        public static int ReadInt(string prompt, int? min = null, int? max = null)
        {
            while (true)
            {
                Console.Write(prompt);
                var s = Console.ReadLine();
                if (!int.TryParse(s, out var v))
                {
                    Console.WriteLine("  Введите целое число.");
                    continue;
                }
                if (min.HasValue && v < min.Value)
                {
                    Console.WriteLine($"  Значение должно быть не меньше {min.Value}.");
                    continue;
                }
                if (max.HasValue && v > max.Value)
                {
                    Console.WriteLine($"  Значение должно быть не больше {max.Value}.");
                    continue;
                }
                return v;
            }
        }

        public static DateTime? ReadOptionalDate(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                var s = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(s)) return null;

                var formats = new[] { "yyyy-MM-dd", "dd.MM.yyyy", "yyyy-MM-dd HH:mm", "dd.MM.yyyy HH:mm" };
                if (DateTime.TryParseExact(s.Trim(), formats, CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out var dt))
                    return dt;

                Console.WriteLine("  Формат: yyyy-MM-dd или yyyy-MM-dd HH:mm (Enter — пропустить).");
            }
        }

        public static string FormatMoney(decimal value) => value.ToString("F2", CultureInfo.InvariantCulture);
        public static string FormatDate(DateTime dt) => dt.ToString("yyyy-MM-dd HH:mm");
    }
}
