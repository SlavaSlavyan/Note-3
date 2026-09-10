namespace TestCS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Name << ");
            string name = Console.ReadLine();

            Console.Write("Age << ");
            int age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Hello, {name}! Your age is {age}.\n\nPress ENTER to exit.");
            

            name = Console.ReadLine();
        }
    }
}
