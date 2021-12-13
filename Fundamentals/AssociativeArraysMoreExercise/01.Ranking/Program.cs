using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contestPassword = new Dictionary<string, string>();
            Dictionary<string, List<string>> userInContests = new Dictionary<string, List<string>>();

            while (true)
            {
                string[] input = Console.ReadLine().Split(':');

                if (input[0] == "end of contests")
                {
                    break;
                }

                string contest = input[0];
                string pass = input[1];

                contestPassword.Add(contest, pass);
            }

            while (true)
            {
                string[] input = Console.ReadLine().Split("=>");

                if (input[0] == "end of submissions")
                {
                    break;
                }

                string contest = input[0];
                string pass = input[1];
                string username = input[2];
                string points = input[3];

                if (contestPassword.ContainsKey(contest)
                    && contestPassword[contest] == pass)
                {
                    if (userInContests.ContainsKey(username))
                    {
                        
                    }
                }

            }

        }
    }
}
