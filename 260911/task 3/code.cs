namespace TestCS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float c;

            Console.Write("Temperature in Celsius << ");
            c = Convert.ToSingle(Console.ReadLine());

            Console.WriteLine($"\nFahrenheit >> {Math.Round((c * 9 / 5 + 32), 2)}" +
                $"\nKelvin >> {Math.Round((c + 273.15),2)}\n\nPress ENTER to exit...\n");

            Console.ReadLine();
        }
    }
}
