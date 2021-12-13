using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _05.NetherRealms
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] inputDemons = Console.ReadLine()
                .Split(new string[] {","}, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToArray();

            Dictionary<string, double[]> demons = new Dictionary<string, double[]>();

            Regex nameRegex = new Regex(@"[^\d\-+.*\/]");
            Regex numbersRegex = new Regex(@"(\+?-?\d+\.?\d*)");
            Regex bonus = new Regex(@"[/*]");

            foreach (var demon in inputDemons)
            {
                MatchCollection nameMatch = nameRegex.Matches(demon);
                var numbersMatch = numbersRegex.Matches(demon);
                var bonuses = bonus.Matches(demon);

                int health = 0;
                double dmg = 0;

                foreach (var match in nameMatch)
                {
                    char curr = char.Parse(match.ToString());
                    health += curr;
                }

                foreach (Match number in numbersMatch)
                {
                    dmg += double.Parse(number.Value);
                }

                foreach (Match bonuse in bonuses)
                {
                    if (bonuse.Value == "/")
                    {
                        dmg /= 2;
                    }
                    else
                    {
                        dmg *= 2;
                    }
                }

                demons.Add(demon, new []{health, dmg});
            }

            demons = demons
                .OrderBy(n => n.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var demon in demons)
            {
                Console.WriteLine($"{demon.Key} - {demon.Value[0]} health, {demon.Value[1]:f2} damage");
            }
        }
    }
}
