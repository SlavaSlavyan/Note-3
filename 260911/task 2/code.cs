namespace TestCS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1, num2;

            Console.Write("Number 1 << ");
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Number 2 << ");
            num2 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"\n{num1} + {num2} = {num1 + num2}\n" +
                $"{num1} - {num2} = {num1 - num2}\n" +
                $"{num1} * {num2} = {num1 * num2}\n" +
                $"{num1} / {num2} = {Math.Round((num1 / (float)num2), 2)}" +
                "\n\nPress ENTER to exit...\n");

            Console.ReadLine();
        }
    }
}
