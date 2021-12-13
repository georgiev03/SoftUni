using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TheV_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> vloggers = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> following = new Dictionary<string, List<string>>();

            while (true)
            {
                string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (tokens[0] == "Statistics")
                {
                    break;
                }

                string vlogger = tokens[0];

                if (tokens[1] == "joined" && !vloggers.ContainsKey(vlogger))
                {
                    vloggers.Add(vlogger, new List<string>());
                    following.Add(vlogger, new List<string>());
                    continue;
                }

                if (IsValid(tokens, vloggers, following))
                {
                    vloggers[tokens[2]].Add(vlogger);
                    following[vlogger].Add(tokens[2]);
                }
            }

            vloggers = vloggers.OrderByDescending(x => x.Value.Count)
                .ThenBy(x => following[x.Key].Count)
                .ToDictionary(x => x.Key, x => x.Value);

            int count = 1;

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            foreach (var vlogger in vloggers)
            {
                Console.WriteLine($"{count}. {vlogger.Key} : {vlogger.Value.Count} followers, {following[vlogger.Key].Count} following");

                if (count == 1)
                {
                    foreach (var follower in vlogger.Value.OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }

                count++;

            }
        }

        private static bool IsValid(string[] tokens, Dictionary<string, List<string>> vloggers, Dictionary<string, List<string>> following)
        {
            return vloggers.ContainsKey(tokens[0]) && vloggers.ContainsKey(tokens[2]) &&
                   tokens[0] != tokens[2] && !vloggers[tokens[2]].Contains(tokens[0]) &&
                   !following[tokens[0]].Contains(tokens[2]);
        }
    }
}
