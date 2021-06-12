using System;

namespace Ex03.ConsoleUI
{
    public class Program
    {
        public static void Main()
        {
            UserInterface startGarageVisit = new UserInterface();
            startGarageVisit.WelcomeGarage();
            Console.Clear();
            Console.WriteLine("Goodbye!");
            Console.WriteLine();
        }
    }
}
