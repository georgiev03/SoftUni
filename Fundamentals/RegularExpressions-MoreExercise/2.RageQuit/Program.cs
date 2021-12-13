using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _2.RageQuit
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Regex regex = new Regex(@"[\D]+[\d]{1,2}");
            Regex symbolsRegex = new Regex(@"[^\d]+");
            Regex timesRegex = new Regex(@"[\d]+");

            MatchCollection matches = regex.Matches(input);

            StringBuilder result = new StringBuilder();
            string unique = string.Empty;

            foreach (Match match in matches)
            {
                Match symbols = symbolsRegex.Match(match.Value.ToUpper());
                Match times = timesRegex.Match(match.Value);
                int count = int.Parse(times.Value);
                if (count == 0)
                {
                    continue;
                }

                foreach (var symbol in symbols.Value)
                {
                    if (!unique.Contains(symbol))
                    {
                        unique += symbol;
                    }
                }

                for (int i = 0; i < count; i++)
                {
                    result.Append(symbols.Value);
                }
            }

            Console.WriteLine($"Unique symbols used: {unique.Length}");
            Console.WriteLine(result);
        }
    }
}
