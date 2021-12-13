using System;

namespace _05.Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());

            switch (product)
            {
                case "coffee":
                    Coffee(quantity);
                    break;
                case "coke":
                    Coke(quantity);
                    break;
                case "water":
                    Water(quantity);
                    break;
                case "snacks":
                    Snacks(quantity);
                    break;
            }
        }

        static void Coffee(int quantity)
        {
            double price = quantity * 1.5;
            Console.WriteLine($"{price:f2}");
        }
        static void Water(int quantity)
        {
            double price = quantity * 1;
            Console.WriteLine($"{price:f2}");
        }
        static void Coke(int quantity)
        {
            double price = quantity * 1.4;
            Console.WriteLine($"{price:f2}");
        }
        static void Snacks(int quantity)
        {
            double price = quantity * 2;
            Console.WriteLine($"{price:f2}");
        }
    }
}
