using Cinema.Results;
using Cinema.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.UI
{
    internal sealed class Menu
    {
        private readonly FilmService _films;
        private readonly ScreeningService _screenings;
        private readonly CustomerService _customers;
        private readonly TicketService _tickets;
        private readonly ReportService _reports;

        public Menu(
            FilmService films,
            ScreeningService screenings,
            CustomerService customers,
            TicketService tickets,
            ReportService reports)
        {
            _films = films;
            _screenings = screenings;
            _customers = customers;
            _tickets = tickets;
            _reports = reports;
        }

        public async Task RunAsync()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("===== КИНОТЕАТР =====");
                Console.WriteLine("1. Показать фильмы");
                Console.WriteLine("2. Поиск фильма по названию");
                Console.WriteLine("3. Расписание сеансов (свободные места)");
                Console.WriteLine("4. Найти клиента и его билеты");
                Console.WriteLine("5. Зарегистрировать клиента");
                Console.WriteLine("6. Купить билет");
                Console.WriteLine("7. Отменить билет");
                Console.WriteLine("8. Отчёт по сеансам + топ-3 фильма");
                Console.WriteLine("0. Выход");
                Console.Write("Выбор: ");

                var choice = Console.ReadLine()?.Trim();
                Console.WriteLine();

                try
                {
                    switch (choice)
                    {
                        case "1": await ShowAllFilmsAsync(); break;
                        case "2": await SearchFilmsAsync(); break;
                        case "3": await ShowScheduleAsync(); break;
                        case "4": await FindCustomerAsync(); break;
                        case "5": await RegisterCustomerAsync(); break;
                        case "6": await PurchaseTicketAsync(); break;
                        case "7": await CancelTicketAsync(); break;
                        case "8": await ShowReportAsync(); break;
                        case "0": return;
                        default: Console.WriteLine("Неизвестный пункт меню."); break;
                    }
                }
                catch (Npgsql.PostgresException ex)
                {
                    Console.WriteLine($"Ошибка БД (код {ex.SqlState}): {ex.MessageText}");
                }
                catch (Npgsql.NpgsqlException ex)
                {
                    Console.WriteLine($"Ошибка соединения с БД: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            }
        }

        // ---------------- Операции меню ----------------

        private async Task ShowAllFilmsAsync()
        {
            var films = await _films.GetAllAsync();
            if (films.Count == 0)
            {
                Console.WriteLine("Фильмов нет.");
                return;
            }

            Console.WriteLine($"{"ID",-4} {"Название",-30} {"Жанр",-15} {"Мин",-5} {"Возраст",-8} {"Год",-5}");
            Console.WriteLine(new string('-', 80));
            foreach (var f in films)
            {
                Console.WriteLine($"{f.FilmId,-4} {Truncate(f.Title, 30),-30} {Truncate(f.Genre, 15),-15} " +
                                  $"{f.DurationMinutes,-5} {f.AgeRating + "+",-8} {f.ReleaseYear,-5}");
            }
        }

        private async Task SearchFilmsAsync()
        {
            var query = ConsoleHelper.ReadNonEmptyString("Часть названия: ");
            var films = await _films.SearchByTitleAsync(query);
            if (films.Count == 0)
            {
                Console.WriteLine("Ничего не найдено.");
                return;
            }

            Console.WriteLine($"{"ID",-4} {"Название",-30} {"Жанр",-15} {"Год",-5}");
            Console.WriteLine(new string('-', 60));
            foreach (var f in films)
                Console.WriteLine($"{f.FilmId,-4} {Truncate(f.Title, 30),-30} {Truncate(f.Genre, 15),-15} {f.ReleaseYear,-5}");
        }

        private async Task ShowScheduleAsync()
        {
            Console.WriteLine("Фильтр по датам (Enter — без ограничения):");
            var from = ConsoleHelper.ReadOptionalDate("С даты (yyyy-MM-dd): ");
            var to = ConsoleHelper.ReadOptionalDate("По дату (yyyy-MM-dd): ");

            var list = await _screenings.GetScheduleAsync(from, to);
            if (list.Count == 0)
            {
                Console.WriteLine("Сеансы не найдены.");
                return;
            }

            Console.WriteLine($"{"ID",-4} {"Фильм",-30} {"Жанр",-12} {"Начало",-17} {"Зал",-8} {"Цена",-7} {"Свободно",-10}");
            Console.WriteLine(new string('-', 100));
            foreach (var s in list)
            {
                Console.WriteLine(
                    $"{s.ScreeningId,-4} {Truncate(s.FilmTitle, 30),-30} {Truncate(s.Genre, 12),-12} " +
                    $"{ConsoleHelper.FormatDate(s.StartsAt),-17} {s.HallName,-8} " +
                    $"{ConsoleHelper.FormatMoney(s.TicketPrice),-7} {s.FreeSeats + " / " + s.TotalSeats,-10}");
            }
        }

        private async Task FindCustomerAsync()
        {
            var email = ConsoleHelper.ReadNonEmptyString("Email клиента: ");
            var customer = await _customers.FindByEmailAsync(email);
            if (customer is null)
            {
                Console.WriteLine($"Клиент с email '{email}' не найден.");
                return;
            }

            Console.WriteLine($"Клиент: #{customer.CustomerId} {customer.FullName} " +
                              $"({customer.Email}, тел: {customer.Phone ?? "—"}), " +
                              $"зарегистрирован {ConsoleHelper.FormatDate(customer.RegisteredAt)}");

            var tickets = await _customers.GetTicketsAsync(customer.CustomerId);
            if (tickets.Count == 0)
            {
                Console.WriteLine("У клиента нет билетов.");
                return;
            }

            Console.WriteLine();
            Console.WriteLine($"{"Билет",-7} {"Фильм",-30} {"Сеанс",-17} {"Зал",-8} {"Место",-6} {"Цена",-7} {"Статус",-12}");
            Console.WriteLine(new string('-', 100));
            foreach (var t in tickets)
            {
                var status = t.Status == "Purchased" ? "куплен" : "отменён";
                Console.WriteLine(
                    $"{t.TicketId,-7} {Truncate(t.FilmTitle, 30),-30} {ConsoleHelper.FormatDate(t.StartsAt),-17} " +
                    $"{t.HallName,-8} {t.SeatNumber,-6} {ConsoleHelper.FormatMoney(t.Price),-7} {status,-12}");
            }
        }

        private async Task RegisterCustomerAsync()
        {
            var firstName = ConsoleHelper.ReadNonEmptyString("Имя: ");
            var lastName = ConsoleHelper.ReadNonEmptyString("Фамилия: ");
            var email = ConsoleHelper.ReadNonEmptyString("Email: ");
            var phone = ConsoleHelper.ReadOptionalString("Телефон (Enter — не указан): ");

            try
            {
                var id = await _customers.RegisterAsync(firstName, lastName, email, phone);
                Console.WriteLine($"Клиент успешно зарегистрирован. ID = {id}.");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async Task PurchaseTicketAsync()
        {
            var screeningId = ConsoleHelper.ReadInt("ID сеанса: ", 1);
            var customerId = ConsoleHelper.ReadInt("ID клиента: ", 1);
            var seatNumber = ConsoleHelper.ReadInt("Номер места: ", 1);

            var result = await _tickets.PurchaseAsync(screeningId, customerId, seatNumber);
            if (!result.IsSuccess)
            {
                Console.WriteLine($"Покупка не выполнена: {result.ErrorMessage}");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("Билет успешно оформлен!");
            Console.WriteLine($"  Номер билета: {result.TicketId}");
            Console.WriteLine($"  Фильм:       {result.FilmTitle}");
            Console.WriteLine($"  Сеанс:       {ConsoleHelper.FormatDate(result.StartsAt)}");
            Console.WriteLine($"  Место:       {result.SeatNumber}");
            Console.WriteLine($"  Цена:        {ConsoleHelper.FormatMoney(result.Price)}");
        }

        private async Task CancelTicketAsync()
        {
            var ticketId = ConsoleHelper.ReadInt("Номер билета: ", 1);
            var result = await _tickets.CancelAsync(ticketId);

            switch (result.Status)
            {
                case CancelStatus.Success:
                    Console.WriteLine($"Билет #{ticketId} отменён. Место снова свободно.");
                    break;
                case CancelStatus.NotFound:
                    Console.WriteLine($"Билет #{ticketId} не найден.");
                    break;
                case CancelStatus.AlreadyCancelled:
                    Console.WriteLine($"Билет #{ticketId} уже отменён.");
                    break;
            }
        }

        private async Task ShowReportAsync()
        {
            var report = await _reports.GetScreeningReportAsync();
            if (report.Count == 0)
            {
                Console.WriteLine("Сеансов нет.");
            }
            else
            {
                Console.WriteLine($"{"ID",-4} {"Фильм",-30} {"Начало",-17} {"Зал",-8} {"Продано",-8} {"Выручка",-10}");
                Console.WriteLine(new string('-', 85));
                foreach (var r in report)
                {
                    Console.WriteLine(
                        $"{r.ScreeningId,-4} {Truncate(r.FilmTitle, 30),-30} " +
                        $"{ConsoleHelper.FormatDate(r.StartsAt),-17} {r.HallName,-8} " +
                        $"{r.SoldTickets,-8} {ConsoleHelper.FormatMoney(r.Revenue),-10}");
                }
            }

            Console.WriteLine();
            Console.WriteLine("Топ-3 фильма по проданным билетам:");
            var top = await _reports.GetTopFilmsAsync(3);
            if (top.Count == 0)
            {
                Console.WriteLine("  (нет данных)");
                return;
            }
            for (var i = 0; i < top.Count; i++)
                Console.WriteLine($"  {i + 1}. {top[i].Title} — {top[i].TicketsSold} шт.");
        }

        // ---------------- вспомогательные ----------------

        private static string Truncate(string s, int max) =>
            s.Length <= max ? s : s[..(max - 1)] + "…";
    }
}
