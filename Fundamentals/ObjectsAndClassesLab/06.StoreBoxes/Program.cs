using System;
using System.Collections.Generic;

namespace _06.StoreBoxes
{
    class Item
    {
        public string Name { get; set; }

        public decimal PriceBox { get; set; }

    }

    class Box
    {
        public Box()
        {
            Item = new Item();
        }
        public string SerialNum { get; set; }

        public Item Item { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Box> boxes = new List<Box>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "end")
                {
                    break;
                }

                string[] tokens = line.Split();

                string serialNum = tokens[0];
                string itemName = tokens[1];
                int quantity = int.Parse(tokens[2]);
                decimal price = decimal.Parse(tokens[3]);

                Box box = new Box
                {
                    Item = new Item
                    {
                        Name = itemName,
                        PriceBox = quantity * price
                    },
                    SerialNum = serialNum,
                    Quantity = quantity,
                    Price = price
                };

                boxes.Add(box);
            }

            boxes.Sort((p1, p2) => p2.Item.PriceBox.CompareTo(p1.Item.PriceBox));
            
            for (int i = 0; i < boxes.Count; i++)
            {
                string serialNum = boxes[i].SerialNum;
                string name = boxes[i].Item.Name;
                decimal price = boxes[i].Price;
                int quantity = boxes[i].Quantity;
                decimal boxPrice = boxes[i].Item.PriceBox;


                Console.WriteLine(serialNum);
                Console.WriteLine($"-- {name} - ${price:f2}: {quantity}");
                Console.WriteLine($"-- ${boxPrice:f2}");
            }
        }
    }
}
