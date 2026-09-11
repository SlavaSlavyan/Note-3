namespace TestCS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1, num2, num3;
            float result;

            Console.Write("Number 1 << ");
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Number 2 << ");
            num2 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Number 3 << ");
            num3 = Convert.ToInt32(Console.ReadLine());

            result = (num1 + num2 + num3) / 3.0f;

            Console.WriteLine($"\nArithmetic mean {(int)result} [{result}]\n\nPress ENTER to exit...");

            Console.ReadLine();
        }
    }
}
