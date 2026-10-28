# FitnessEf — учебный проект EF Core + PostgreSQL

**МОСКО СВЯТОСЛАВ ЮРЬЕВИЧ**

Консольное приложение для управления клиентами фитнес-клуба на EF Core 8 и PostgreSQL.
Практика Code First в отдельной учебной базе **FitnessEfTraining**.

## Стек
- .NET 8 (LTS)
- EF Core 8 + Npgsql
- PostgreSQL (localhost:5432)

## Переменная окружения
Приложению нужна переменная `FITNESS_EF_CONNECTION`. Пример для PowerShell:

    $env:FITNESS_EF_CONNECTION = "Host=localhost;Port=5432;Database=FitnessEfTraining;Username=postgres;Password=YOUR_PASSWORD"

## Сборка и запуск
    dotnet restore
    dotnet build
    dotnet run

## Миграции
    dotnet tool install --global dotnet-ef   # или: dotnet tool update --global dotnet-ef
    dotnet ef migrations add InitialCreate
    dotnet ef database update
    # после добавления Visit:
    dotnet ef migrations add AddVisits
    dotnet ef database update

## Демо-данные
Выполнить `Sql/01_demo_data.sql` в базе FitnessEfTraining (через pgAdmin или psql).
Проверка схемы — `Sql/02_verify_schema.sql`.

## Соответствие заданиям
1. Окружение и проект — csproj + NuGet.
2. Модель и контекст — `Models/Client.cs`, `Data/FitnessContext.cs`.
3. Миграции и база — команды выше + `Sql/02_verify_schema.sql`.
4. Чтение, сортировка, проекция — `ClientService.GetAllAsync/GetProjectedAsync`.
5. Фильтрация и поиск — `Where`, `FindAsync`, `CountAsync`, `AnyAsync`, `SearchByLastNameAsync`, `GetPageAsync`.
6. Добавление — `ClientService.AddAsync` + `DbUpdateException` в `ConsoleMenu`.
7. Изменение и удаление — `UpdatePhoneAsync`, `UpdateStatusAsync`, `DeleteAsync`.
8. NULL и типы — Fluent API + проверки обязательных полей.
9. Связь Client–Visit — `Visit`, `Include`, `DeleteBehavior.Restrict`.
10. Миграции и существующая база — `migrations list`, `has-pending-model-changes`; scaffold описан в README.
11. Ошибки, async, tracking, SQL — `AsNoTracking`, `SaveChangesAsync`, try-catch, `ToQueryString`.
12. Итоговый CRUD-консольный интерфейс — `UI/ConsoleMenu.cs`.