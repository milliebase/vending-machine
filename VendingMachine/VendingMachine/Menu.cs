using System;
using System.Collections.Generic;

namespace VendingMachine
{
    public class Menu
    {
        public void Selection()
        {
            Console.WriteLine("\nMENU");
            Console.WriteLine("> {0,-10} {1,-20}", "purchase", "If you want to buy an item");
            Console.WriteLine("> {0,-10} {1,-20}", "balance", "If you want to see your current balance");
            Console.WriteLine("> {0,-10} {1,-20}", "history", "If you want to see your items");
            Console.WriteLine("> {0,-10} {1,-20}\n", "quit", "If you want to get out of here!");
        }

        public void PurchaseSelection()
        {
            Console.WriteLine("\nPURCHASE MENU");
            Console.WriteLine("> {0,-10} {1,-20}", "purchase", "If you want to buy something else");
            Console.WriteLine("> {0,-10} {1,-20}", "deposit", "If you want to deposit money to your virtual account!");
            Console.WriteLine("> {0,-10} {1,-20}", "balance", "If you want to see your current balance");
            Console.WriteLine("> {0,-10} {1,-20}\n", "exit", "If you want to go back to the main menu");
        }

        public string GetSelection(List<string> command)
        {
            while (true)
            {
                Console.Write("Select: ");
                Console.ForegroundColor = ConsoleColor.Green;

                var input = Console.ReadLine();
                Console.ResetColor();

                if (command.Contains(input))
                {
                    return input;
                }
                
                Error("Please make a valid selection");
            }
        }

        public void BuySuccess(string item)
        {
            Console.WriteLine($"Yay! You bought {item.ToLower()}\n");
        }

        public void Error(string error)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{error}\n");
            Console.ResetColor();
        }
    }
}