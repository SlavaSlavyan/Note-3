using System.Text;
using FitnessEf.Services;
using FitnessEf.UI;

namespace FitnessEf;

internal static class Program
{
    private static async Task<int> Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        try
        {
            var menu = new ConsoleMenu(
                new ClientService(),
                new VisitService(),
                new StatisticsService());

            await menu.RunAsync();
            return 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Критическая ошибка: {ex.Message}");
            return 1;
        }
    }
}