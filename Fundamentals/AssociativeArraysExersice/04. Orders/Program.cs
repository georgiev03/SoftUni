using System;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace _04._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double[]> products = new Dictionary<string, double[]>();

            while (true)
            {
                string[] line = Console.ReadLine().Split();

                if (line[0] == "buy")
                {
                    break;
                }

                string item = line[0];
                double price = double.Parse(line[1]);
                int quantity = int.Parse(line[2]);

                if (products.ContainsKey(item))
                {
                    products[item][0] = price;
                    products[item][1] += quantity;
                }
                else
                {
                    products.Add(item, new []{price, quantity});
                }
            }

            foreach (var product in products)
            {
                double price = product.Value[0] * product.Value[1];

                Console.WriteLine($"{product.Key} -> {price:f2}");
            }
        }
    }
}
