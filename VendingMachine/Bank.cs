using System;

namespace VendingMachine
{
    public class Bank
    {
        private int Balance { get; set; } = 100;
        private Menu Menu { get; }

        public Bank(Menu menu)
        {
            Menu = menu;
        }
        public int GetBalance()
        {
            return Balance;
        }

        public void Withdrawal(int cash)
        {
            Balance -= cash;
            
            BankMessage("New balance after purchase: $");
        }

        public void Deposit()
        {
            Console.Clear();

            while (true)
            {
                Console.Write("How much would you like to deposit?: $");
                var amount = Console.ReadLine();

                var validAmount = Int32.TryParse(amount, out int value);

                if (!validAmount)
                {
                    Menu.Error("Please insert a valid number");
                }
                
                if (value > 100 || value <= 0)
                {
                    Menu.Error("You can only deposit a maximum of $100 and a minimum of $1");
                }
                
                if(validAmount && Balance + value > 500)
                {
                    Menu.Error("Sorry, you can only have a total balance of $500");
                    BankMessage("Your current balance is: $");
                    break;
                }
                
                if(validAmount && value <= 100 && value > 0)
                {
                    Balance += value;
                    BankMessage("New balance after deposit: $");
                    break;
                }
            }
        }

        public void BankMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine($"{message}{Balance}");
            Console.ResetColor();
        }
    }
}