namespace TestCS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a, b, c;
            float D;

            Console.Write("A << ");
            a = Convert.ToInt32(Console.ReadLine());
            Console.Write("B << ");
            b = Convert.ToInt32(Console.ReadLine());
            Console.Write("C << ");
            c = Convert.ToInt32(Console.ReadLine());

            if (a == 0)
            {
                Console.WriteLine("Error! Not an quadratic function.\n\nPress any key to exit...");
                Console.ReadLine();
                return;
            }

            D = b * b - 4.0f * a * c;

            Console.WriteLine($"\nDiscriminant >> {D:0.000}");

            if (D > 0)
            {
                Console.WriteLine("Two roots!");
            }
            else if (D < 0)
            {
                Console.WriteLine("Zero roots!");
            }
            else
            {
                Console.WriteLine("One root!");
            }

            Console.WriteLine("\nPress ENTER to exit...");
            Console.ReadLine();
        }
    }
}
