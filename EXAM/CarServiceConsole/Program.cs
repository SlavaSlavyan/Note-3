using CarServiceConsole.UI;

namespace CarServiceConsole
{
    internal class Program
    {
        public static string CONNECTION_STR = 
            "Host=localhost;" +
            "Port=5432;" +
            "Database=CarService;" +
            "Username=postgres;" +
            "Password=admin;";
        static void Main(string[] args)
        {
            while (true)
            {
                int _userInput = Menu.UserInput();

                if (_userInput == 0)
                {
                    break;
                }

                Menu.StartFunction(_userInput);
            }
        }
    }
}
