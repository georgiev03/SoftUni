using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._SoftUni_Exam_Results
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> pointsPerUser = new Dictionary<string, int>();

            Dictionary<string, int> languageParticipants = new Dictionary<string, int>();

            while (true)
            {
                string[] tokens = Console.ReadLine().Split('-');

                if (tokens[0] == "exam finished")
                {
                    break;
                }

                string username = tokens[0];

                if (tokens.Length == 3)
                {
                    string language = tokens[1];
                    int points = int.Parse(tokens[2]);

                    if (pointsPerUser.ContainsKey(username))
                    {
                        if (pointsPerUser[username] < points)
                        {
                            pointsPerUser[username] = points;
                        }
                    }
                    else
                    {
                        pointsPerUser.Add(username, points);
                    }

                    if (languageParticipants.ContainsKey(language))
                    {
                        languageParticipants[language]++;
                    }
                    else
                    {
                        languageParticipants.Add(language, 1);
                    }
                }
                else
                {
                    pointsPerUser.Remove(username);
                }
            }

            pointsPerUser = pointsPerUser
                .OrderByDescending(p => p.Value)
                .ThenBy(n => n.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            languageParticipants = languageParticipants
                .OrderByDescending(p => p.Value)
                .ThenBy(n => n.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine("Results:");

            foreach (var kvp in pointsPerUser)
            {
                Console.WriteLine($"{kvp.Key} | {kvp.Value}");
            }

            Console.WriteLine("Submissions:");

            foreach (var kvp in languageParticipants)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
            }
        }
    }
}
