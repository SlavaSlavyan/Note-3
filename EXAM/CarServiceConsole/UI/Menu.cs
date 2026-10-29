using System;
using System.Collections.Generic;
using System.Text;

namespace CarServiceConsole.UI
{
    internal class Menu
    {
        public static int UserInput()
        {
            int _userInput;

            while (true)
            {
                Console.Clear();
                Console.Write("==========CAR=SERVICE=CONSOLE=SLL==========\n\n" +
                    "  1. Add new car\n" +
                    "  0. Exit\n\n> ");

                try
                {
                    _userInput = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Error: Invalid Input!");
                    Console.ReadLine();
                    continue;
                }

                if (_userInput < 0 || _userInput > 1)
                {
                    Console.Clear();
                    Console.WriteLine("Error: No such function!");
                    Console.ReadLine();
                    continue;
                }

                return _userInput;
            }
        }

        public static void StartFunction(int functionID)
        {
            switch (functionID)
            {
                case 1:
                    Service.Car.Add();
                    break;

                default:
                    throw new ArgumentException("No such function found!");
            }
        }
    }
}
