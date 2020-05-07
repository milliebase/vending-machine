using System;
using System.Collections.Generic;

namespace VendingMachine
{
    public class User
    {
        private readonly List<string> _userHistory = new List<string>();

        public void AddToHistory(string item)
        {
            _userHistory.Add(item);
        }

        public void ListHistory()
        {
            Console.Clear();
            
            if (_userHistory.Count == 0)
            {
                Console.WriteLine("There is no history here! Go buy something");
            }
            else
            {
                var count = 1;
                
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nYOUR HISTORY OF PURCHASED ITEMS:\n");

                Console.ForegroundColor = ConsoleColor.Yellow;
                foreach (var item in _userHistory)
                {
                    Console.WriteLine("{0,3}. {1,-15}", count, item);
                    count++;
                }
                Console.ResetColor();
            }
        }
    }
}