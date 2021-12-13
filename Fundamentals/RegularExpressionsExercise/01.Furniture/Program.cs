using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01.Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@">>(?<name>[A-Za-z]+)<<(?<price>\d+\.?\d*)!(?<quantity>\d+)");

            double totalPrice = 0;
            List<string> products = new List<string>();

            while (true)
            {
                string product = Console.ReadLine();

                if (product == "Purchase")
                {
                    break;
                }

                var match = regex.Match(product);

                if (!match.Success)
                {
                    continue;
                }

                products.Add(match.Groups["name"].Value);

                totalPrice += double.Parse(match.Groups["price"].Value) * int.Parse(match.Groups["quantity"].Value);
            }

            Console.WriteLine("Bought furniture:");

            foreach (var product in products)
            {
                Console.WriteLine(product);
            }

            Console.WriteLine($"Total money spend: {totalPrice:f2}");
        }
    }
}
