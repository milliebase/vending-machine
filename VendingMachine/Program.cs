using System;
using System.Collections.Generic;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            var vendingMachine = new VendingMachine(
                new Menu(),
                new Inventory(),
                new User(),
                new Bank(new Menu())
            );

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("WELCOME TO THE VIRTUAL VENDING MACHINE!\n");
            Console.ResetColor();
            Console.WriteLine("\nWhat would you like to do?");
            
            vendingMachine.Start();
        }
    }
}