using System;
using System.Collections.Generic;

namespace VendingMachine
{
    public class Inventory
    {
        private readonly List<GoodsItem> _items = new List<GoodsItem>();
        
        public Inventory()
        {
            _items.Add(new GoodsItem("Soda", 25, 110));
            _items.Add(new GoodsItem("Chips", 20, 120));
            _items.Add(new GoodsItem("Candy bar", 10, 130));
            _items.Add(new GoodsItem("Peanuts", 20, 140));
            _items.Add(new GoodsItem("Lollipop", 5, 150));
        }

        public void ListItems()
        {
            if (_items.Count == 0)
            {
                Console.WriteLine("The vending machine is unfortunately empty");
                return;   
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("     ********** INVENTORY ********* \n");
            Console.WriteLine("  {0,-5}  {1,-15}  {2,-5}  {3,-8}\n\n", "CODE", "ITEM", "COST", "QUANTITY");

            foreach (var item in _items)
            {
                Console.WriteLine("| {0,-5}| {1,-15}| ${2,5}| {3,8}|", item.Code, item.Description, item.Prize, item.Quantity);
            }

            Console.WriteLine();
            Console.ResetColor();
        }

        public List<string> GetCodes()
        {
            var codes = new List<string>();

            foreach (var item in _items)
            {
                codes.Add(item.Code.ToString());
            }

            return codes;
        }

        public string GetItem(string code)
        {
            foreach (var item in _items)
            {
                if (item.Code == Int32.Parse(code))
                {
                    return item.Description;
                }
            }

            throw new ArgumentException("The item doesn't exist in inventory!", nameof(code));
        }

        public int GetCost(string code)
        {
            foreach (var item in _items)
            {
                if (item.Code == Int32.Parse(code))
                {
                    return item.Prize;
                }
            }

            throw new ArgumentException("The item doesn't exist in inventory!", nameof(code));
        }
    }
}