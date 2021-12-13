using System;
using System.Collections.Generic;

namespace _03.ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, double>> shop =
                new SortedDictionary<string, Dictionary<string, double>>();


            while (true)
            {
                string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "Revision")
                {
                    break;
                }

                string store = input[0];
                string food = input[1];
                double price = double.Parse(input[2]);

                if (!shop.ContainsKey(input[0]))
                {
                    shop.Add(store, new Dictionary<string, double>());
                }

                shop[store].Add(food, price);
            }

            foreach (var kvp in shop)
            {
                Console.WriteLine($"{kvp.Key}->");
                foreach (var products in kvp.Value)
                {
                    Console.WriteLine($"Product: {products.Key}, Price: {products.Value}");
                }
            }
        }
    }
}
