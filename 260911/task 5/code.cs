namespace TestCS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1, num2;
            string operation;

            Console.Write("Number 1 << ");
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Number 2 << ");
            num2 = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nChose operation:\n  1. Sum\n  2. Difference\n  3. Multiplication\n  4. Division\n\n> ");
            operation = Console.ReadLine();

            Console.Write("\nResult >> ");

            switch (operation)
            {
                case "1":
                    Console.WriteLine($"{num1} + {num2} = {num1 + num2}");
                    break;
                case "2":
                    Console.WriteLine($"{num1} - {num2} = {num1 - num2}");
                    break;
                case "3":
                    Console.WriteLine($"{num1} * {num2} = {num1 * num2}");
                    break;

                case "4":
                    if (num2 == 0)
                    {
                        Console.WriteLine("Error! Division by zero.");
                    } 
                    else
                    {
                        Console.WriteLine($"{num1} / {num2} = {num1 / num2}");
                    }

                    break;

                default:
                    Console.WriteLine($"Unknown operation \"{operation}\".");
                    break;
            }

            Console.WriteLine("\nPress ENTER to exit\n");
            Console.ReadLine();
        }
    }
}
