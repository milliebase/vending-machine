using System;

namespace VendingMachine
{
    public class GoodsItem
    {
        public string Description { get; set;  }
        public int Quantity { get; set; } = 10;
        public int Prize { get; set; }
        public int Code { get; set; }
        

        public GoodsItem(string description, int prize, int code)
        {
            if (prize <= 0)
                throw new ArgumentException("Prize of goods item can't be zero or negative", nameof(prize));

            Description = description;
            Prize = prize;
            Code = code;
        }
    }
}