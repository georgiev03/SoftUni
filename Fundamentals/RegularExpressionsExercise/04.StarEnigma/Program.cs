using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _04.StarEnigma
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Regex regexCounter = new Regex(@"[starSTAR]");
            Regex regex = new Regex(@"@(?<name>[a-zA-Z]+)[^@\-!:>]*:(\d+).*!(?<type>[AD])![^@\-!:>]*->(\d+)");

            Dictionary<string, List<string>> planets = new Dictionary<string, List<string>>
            {
                { "attacked", new List<string>() },
                { "destroyed", new List<string>() }
            };

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                MatchCollection keys = regexCounter.Matches(input);
                StringBuilder sb = new StringBuilder();

                foreach (var symbol in input)
                {
                    sb.Append((char)(symbol - keys.Count));
                }

                Match matchedPlanets = regex.Match(sb.ToString());
                if (matchedPlanets.Success)
                {
                    if (matchedPlanets.Groups["type"].Value == "A")
                    {
                        string planetName = matchedPlanets.Groups["name"].Value;
                        planets["attacked"].Add(planetName);
                    }
                    else
                    {
                        string planetName = matchedPlanets.Groups["name"].Value;
                        planets["destroyed"].Add(planetName);
                    }
                }
            }

            Console.WriteLine($"Attacked planets: {planets["attacked"].Count}");

            planets["attacked"].Sort();
            foreach (var pl in planets["attacked"])
            {
                Console.WriteLine($"-> {pl}");
            }

            Console.WriteLine($"Destroyed planets: {planets["destroyed"].Count}");
            planets["destroyed"].Sort();
            foreach (var pl in planets["destroyed"])
            {
                Console.WriteLine($"-> {pl}");
            }
        }
    }
}
