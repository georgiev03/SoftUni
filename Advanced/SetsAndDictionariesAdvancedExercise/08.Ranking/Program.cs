using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contestAndPass = new Dictionary<string, string>();
            SortedDictionary<string, Dictionary<string, int>> contestants = new SortedDictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string[] input = Console.ReadLine().Split(':');

                if (input[0] == "end of contests")
                {
                    break;
                }

                contestAndPass[input[0]] = input[1];
            }

            while (true)
            {
                string[] input = Console.ReadLine().Split("=>");

                if (input[0] == "end of submissions")
                {
                    break;
                }

                string contest = input[0];
                string password = input[1];
                string username = input[2];
                int points = int.Parse(input[3]);

                if (!contestAndPass.ContainsKey(contest))
                {
                    continue;
                }

                if (contestAndPass[contest] != password)
                {
                    continue;
                }

                if (!contestants.ContainsKey(username))
                {
                    contestants.Add(username, new Dictionary<string, int>());
                }

                if (!contestants[username].ContainsKey(contest))
                {
                    contestants[username].Add(contest,points);
                }

                if (contestants[username][contest] < points)
                {
                    contestants[username][contest] = points;
                }
            }

            var bestStudent = contestants
                .OrderByDescending(x => x.Value.Values.Sum());


            foreach (var contestant in bestStudent)
            {
                Console.WriteLine($"Best candidate is {contestant.Key} with total {contestant.Value.Values.Sum()} points.");
                Console.WriteLine("Ranking:");
                break;
            }

            foreach (var contestant in contestants)
            {
                Console.WriteLine(contestant.Key);

                foreach (var kvp in contestant.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {kvp.Key} -> {kvp.Value}");
                }
            }
        }
    }
}
