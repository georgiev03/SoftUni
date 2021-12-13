using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.Race
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> racers = Console.ReadLine()
                .Split(", ")
                .ToDictionary(x => x, x => 0);

            Regex nameRegex = new Regex(@"[a-zA-Z]");
            Regex pointsRegex = new Regex(@"\d");

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end of race")
                {
                    break;
                }

                var name = nameRegex.Matches(input);
                var points = pointsRegex.Matches(input);

                StringBuilder sb = new StringBuilder();

                foreach (Match match in name)
                {
                    sb.Append(match);
                }

                if (racers.ContainsKey(sb.ToString()))
                {
                    racers[sb.ToString()] += points.Select(x => int.Parse(x.Value.ToString())).Sum();
                }
            }

            string[] winners = racers
                .OrderByDescending(x => x.Value)
                .Take(3)
                .Select(r => r.Key)
                .ToArray();

            Console.WriteLine($"1st place: {winners[0]}");
            Console.WriteLine($"2nd place: {winners[1]}");
            Console.WriteLine($"3rd place: {winners[2]}");
        }
    }
}
