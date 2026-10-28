using FitnessEf.Models;
using FitnessEf.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace FitnessEf.UI
{
    internal sealed class ConsoleMenu
    {
        private readonly IClientService _clients;
        private readonly IVisitService _visits;
        private readonly IStatisticsService _stats;

        public ConsoleMenu(IClientService clients, IVisitService visits, IStatisticsService stats)
        {
            _clients = clients;
            _visits = visits;
            _stats = stats;
        }

        public async Task RunAsync()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("=== FitnessEf — управление клиентами ===");
                Console.WriteLine("1. Список клиентов");
                Console.WriteLine("2. Найти клиента по ID");
                Console.WriteLine("3. Добавить клиента");
                Console.WriteLine("4. Изменить телефон / статус");
                Console.WriteLine("5. Удалить клиента");
                Console.WriteLine("6. Статистика");
                Console.WriteLine("7. Поиск по фамилии");
                Console.WriteLine("8. Клиенты с посещениями");
                Console.WriteLine("9. Добавить посещение");
                Console.WriteLine("0. Выход");
                Console.Write("Выбор: ");

                var choice = Console.ReadLine() ?? string.Empty;
                if (choice == "0") return;

                try
                {
                    switch (choice)
                    {
                        case "1": await ListClientsAsync(); break;
                        case "2": await FindClientAsync(); break;
                        case "3": await AddClientAsync(); break;
                        case "4": await UpdateClientAsync(); break;
                        case "5": await DeleteClientAsync(); break;
                        case "6": await ShowStatisticsAsync(); break;
                        case "7": await SearchByLastNameAsync(); break;
                        case "8": await ListClientsWithVisitsAsync(); break;
                        case "9": await AddVisitAsync(); break;
                        default: Console.WriteLine("Неизвестный пункт меню."); break;
                    }
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine($"Ошибка конфигурации: {ex.Message}");
                }
                catch (DbUpdateException ex)
                {
                    Console.WriteLine("Ошибка сохранения данных. Проверьте ограничения БД.");
                    Console.WriteLine(ex.GetBaseException().Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Непредвиденная ошибка.");
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private async Task ListClientsAsync()
        {
            var list = await _clients.GetProjectedAsync();
            if (list.Count == 0)
            {
                Console.WriteLine("Клиентов нет.");
                return;
            }

            foreach (var c in list)
                Console.WriteLine($"{c.ClientId}: {c.FullName}; тел.: {c.Phone ?? "не указан"}");
        }

        private async Task FindClientAsync()
        {
            int id = ConsoleHelper.ReadPositiveInt("ID клиента: ");
            var client = await _clients.FindByIdAsync(id);
            if (client is null)
            {
                Console.WriteLine("Клиент не найден.");
                return;
            }

            Console.WriteLine($"{client.ClientId}: {client.FirstName} {client.LastName}");
            Console.WriteLine($"  Статус: {client.Status}");
            Console.WriteLine($"  Телефон: {client.Phone ?? "—"}");
            Console.WriteLine($"  Email: {client.Email ?? "—"}");
            Console.WriteLine($"  Дата рождения: {client.BirthDate?.ToString("yyyy-MM-dd") ?? "—"}");
            Console.WriteLine($"  Дата регистрации: {client.RegistrationDate:yyyy-MM-dd}");
        }

        private async Task AddClientAsync()
        {
            var firstName = ConsoleHelper.ReadRequired("Имя: ");
            var lastName = ConsoleHelper.ReadRequired("Фамилия: ");
            var phone = ConsoleHelper.ReadOptional("Телефон (необязательно): ");
            var email = ConsoleHelper.ReadOptional("Email (необязательно): ");

            var client = new Client
            {
                FirstName = firstName,
                LastName = lastName,
                Phone = phone,
                Email = email,
                RegistrationDate = DateOnly.FromDateTime(DateTime.Today),
                Status = "active"
            };

            try
            {
                await _clients.AddAsync(client);
                Console.WriteLine($"Клиент добавлен. ID: {client.ClientId}");
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine("Не удалось сохранить клиента. Проверьте данные.");
                Console.WriteLine(ex.GetBaseException().Message);
            }
        }

        private async Task UpdateClientAsync()
        {
            int id = ConsoleHelper.ReadPositiveInt("ID клиента: ");
            Console.WriteLine("1. Телефон   2. Статус");
            var field = Console.ReadLine();

            if (field == "1")
            {
                var phone = ConsoleHelper.ReadOptional("Новый телефон (пусто — очистить): ");
                bool ok = await _clients.UpdatePhoneAsync(id, phone ?? string.Empty);
                Console.WriteLine(ok ? "Телефон обновлён." : "Клиент не найден.");
            }
            else if (field == "2")
            {
                var status = ConsoleHelper.ReadRequired("Новый статус (active/inactive): ");
                bool ok = await _clients.UpdateStatusAsync(id, status);
                Console.WriteLine(ok ? "Статус обновлён." : "Клиент не найден.");
            }
            else
            {
                Console.WriteLine("Неизвестное поле.");
            }
        }

        private async Task DeleteClientAsync()
        {
            int id = ConsoleHelper.ReadPositiveInt("ID клиента для удаления: ");

            var result = await _clients.DeleteAsync(id);
            switch (result)
            {
                case DeleteResult.Deleted:
                    Console.WriteLine("Клиент удалён.");
                    break;
                case DeleteResult.NotFound:
                    Console.WriteLine("Клиент не найден.");
                    break;
                case DeleteResult.HasRelatedVisits:
                    Console.WriteLine("Удаление невозможно: у клиента есть посещения (FK Restrict).");
                    break;
            }
        }

        private async Task ShowStatisticsAsync()
        {
            var s = await _stats.GetAsync();
            Console.WriteLine($"Всего клиентов: {s.Total}");
            Console.WriteLine($"Активных: {s.Active}");
            Console.WriteLine(s.HasInactive ? "Есть неактивные клиенты." : "Неактивных нет.");
        }

        private async Task SearchByLastNameAsync()
        {
            var term = ConsoleHelper.ReadRequired("Фрагмент фамилии: ");
            var found = await _clients.SearchByLastNameAsync(term);
            if (found.Count == 0)
            {
                Console.WriteLine("Ничего не найдено.");
                return;
            }

            foreach (var c in found)
                Console.WriteLine($"{c.ClientId}: {c.FirstName} {c.LastName}");
        }

        private async Task ListClientsWithVisitsAsync()
        {
            var clients = await _visits.GetClientsWithVisitsAsync();
            foreach (var c in clients)
            {
                Console.WriteLine($"{c.FirstName} {c.LastName}");
                if (c.Visits.Count == 0)
                {
                    Console.WriteLine("  (посещений нет)");
                    continue;
                }
                foreach (var v in c.Visits)
                    Console.WriteLine($"  {v.VisitDate:yyyy-MM-dd}: {v.Note ?? "—"}");
            }
        }

        private async Task AddVisitAsync()
        {
            int clientId = ConsoleHelper.ReadPositiveInt("ID клиента: ");
            var date = ConsoleHelper.ReadDate("Дата посещения (ГГГГ-ММ-ДД): ");
            var note = ConsoleHelper.ReadOptional("Заметка (необязательно): ");

            var result = await _visits.AddVisitAsync(clientId, date, note);
            Console.WriteLine(result == AddVisitResult.Added
                ? "Посещение добавлено."
                : "Клиент с таким ID не найден.");
        }
    }
}
