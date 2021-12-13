using System;

namespace _07.VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            string coin = Console.ReadLine();
            double sum = 0;
            while (coin != "Start")
            {
                switch (coin)
                {
                    case "0.1":
                        sum += 0.1;
                        break;
                    case "0.2":
                        sum += 0.2;
                        break;
                    case "0.5":
                        sum += 0.5;
                        break;
                    case "1":
                        sum += 1;
                        break;
                    case "2":
                        sum += 2;
                        break;
                    default:
                        Console.WriteLine($"Cannot accept {coin}");
                        break;
                }
                coin = Console.ReadLine();
            }
            string product = Console.ReadLine();
            while (product != "End")
            {
                bool invalid = false;
                double price = 0;
                switch (product)
                {
                    case "Nuts":
                        price = 2;
                        break;
                    case "Water":
                        price = 0.7;
                        break;
                    case "Crisps":
                        price = 1.5;
                        break;
                    case "Soda":
                        price = 0.8;
                        break;
                    case "Coke":
                        price = 1;
                        break;
                    default:
                        Console.WriteLine("Invalid product");
                        invalid = true;
                        break;
                }
                if(price > sum)
                {
                    Console.WriteLine("Sorry, not enough money");
                }
                else if (invalid)
                {

                }
                else
                {
                    sum -= price;
                    Console.WriteLine($"Purchased {product.ToLower()}");
                }
                product = Console.ReadLine();
            }
            Console.WriteLine($"Change: {sum:f2}");
        }
    }
}
