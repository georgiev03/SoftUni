using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace adastra
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([#|])(?<product>[A-Za-z\s]+)\1(?<expDate>[\d]{2}\/[\d]{2}\/[\d]{2})\1(?<calories>\d{1,5})\1";

            string products = Console.ReadLine();

            var matches = Regex.Matches(products, pattern);

            int calories = matches
                .Select(c => int.Parse(c.Groups["calories"].ToString()))
                .Sum();

            Console.WriteLine($"You have food to last you for: {calories / 2000} days!");

            foreach (Match match in matches)
            {
                var item = match.Groups["product"].Value;
                var expDate = match.Groups["expDate"].Value;
                var nutrition = match.Groups["calories"].Value;

                Console.WriteLine($"Item: {item}, Best before: {expDate}, Nutrition: {nutrition}");
            }
        }
    }
}
