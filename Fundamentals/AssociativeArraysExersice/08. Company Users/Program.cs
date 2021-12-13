using System;
using System.Collections.Generic;

namespace _08._Company_Users
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, List<string>> companies = new SortedDictionary<string, List<string>>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                string[] tokens = input.Split(" -> ");

                string company = tokens[0];
                string id = tokens[1];

                if (companies.ContainsKey(company))
                {
                    if (companies[company].Contains(id))
                    {
                        continue;
                    }

                    companies[company].Add(id);
                }
                else
                {
                    companies.Add(company, new List<string> { id });
                }
            }

            foreach (var kvp in companies)
            {
                Console.WriteLine(kvp.Key);

                foreach (var user in kvp.Value)
                {
                    Console.WriteLine($"-- {user}");    
                }
            }
        }
    }
}
