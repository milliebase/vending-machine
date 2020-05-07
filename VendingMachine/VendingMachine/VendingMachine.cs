using System;
using System.Collections.Generic;

namespace VendingMachine
{
    public class VendingMachine
    {
        private User User { get; }
        private Bank Bank { get; }
        private Menu Menu { get; }

        private Inventory Inventory { get; }
        
        private readonly List<string> _menuSelections = new List<string>
        {
            "purchase",
            "balance",
            "history",
            "quit",
            "h"
        };
        
        private readonly List<string> _purchaseSelections = new List<string>
        {
            "purchase",
            "deposit",
            "balance",
            "exit"
        };

        public VendingMachine(Menu menu, Inventory inventory, User user, Bank bank)
        {
            Menu = menu;
            Inventory = inventory;
            User = user;
            Bank = bank;
        }

        public void Start()
        {
            Menu.Selection();

            while (true)
            {
                var command = Menu.GetSelection(_menuSelections);
                
                if (command.ToLower() == "purchase")
                {
                    Purchase();
                    break;
                }

                if (command.ToLower() == "balance")
                {
                    Bank.BankMessage("Your current balance is: $");
                }

                if (command.ToLower() == "history")
                {
                    User.ListHistory();
                }

                if (command.ToLower() == "quit")
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta; 
                    Console.WriteLine("\nBye, see you next time!\n");
                    Console.ResetColor();

                    break;
                }

                if (command.ToLower() == "h" || command.ToLower() == "exit")
                {
                    Console.Clear();
                    Menu.Selection();
                }

                if (command.ToLower() != "h" || command.ToLower() != "purchase")
                {
                    Console.WriteLine("\nWhat would you like to do next?");
                    Console.WriteLine("Press 'h' if you want to see menu selection again.\n");
                }
            }
        }

        private void Purchase()
        {
            Console.Clear();
            Inventory.ListItems();
            Console.WriteLine("What would you like to buy? Make your selection with the code found above\n");
            Bank.BankMessage("Your current balance is: $");

            var buySelections = Inventory.GetCodes();
            var selectedItem = Menu.GetSelection(buySelections);
            
            var item = Inventory.GetItem(selectedItem);
            var itemCost = Inventory.GetCost(selectedItem);

            var balance = Bank.GetBalance();

            if (itemCost <= balance)
            {
                Menu.BuySuccess(item);
                Bank.Withdrawal(itemCost);

                User.AddToHistory(item);

                Console.WriteLine("\nWant to buy something else?");
                PurchaseMenu();
            }
            else
            {
                Menu.Error("You don't have enough money to buy this item!");
                Console.WriteLine("\nOut of money?");

                PurchaseMenu();
            }
        }

        private void PurchaseMenu()
        {
            while (true)
            {
                Menu.PurchaseSelection();
                var command = Menu.GetSelection(_purchaseSelections);

                if(command.ToLower() == "purchase")
                {
                    Purchase();
                }

                if(command.ToLower() == "deposit")
                {
                    Bank.Deposit();
                }

                if(command.ToLower() == "balance")
                {
                    Bank.BankMessage("Your current balance is: $");
                }

                if (command.ToLower() == "exit")
                {
                    break;
                }
            }
            
            Console.Clear();
            Start();
        }
    }
}