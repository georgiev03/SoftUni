using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Peter
    {
        public int Likes { get; set; }

        public int Comments { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Peter> followers = new Dictionary<string, Peter>();

            while (true)
            {
                string[] lines = Console.ReadLine().Split(": ");
                string command = lines[0];

                if (command == "Log out")
                {
                    break;
                }

                if (command == "New follower")
                {
                    string follower = lines[1];

                    if (followers.ContainsKey(follower))
                    {
                        continue;
                    }

                    followers[follower] = new Peter
                    {
                        Comments = 0,
                        Likes = 0
                    };
                }
                else if (command == "Like")
                {
                    string username = lines[1];
                    int count = int.Parse(lines[2]);

                    if (followers.ContainsKey(username))
                    {
                        followers[username].Likes += count;
                    }
                    else
                    {
                        followers[username] = new Peter
                        {
                            Comments = 0,
                            Likes = count
                        };
                    }
                }
                else if (command == "Comment")
                {
                    string username = lines[1];
                    if (followers.ContainsKey(username))
                    {
                        followers[username].Comments++;
                    }
                    else
                    {
                        followers[username] = new Peter
                        {
                            Comments = 1,
                            Likes = 0
                        };
                    }
                }
                else if (command == "Blocked")
                {
                    string username = lines[1];
                    if (followers.ContainsKey(username))
                    {
                        followers.Remove(username);
                    }
                    else
                    {
                        Console.WriteLine($"{username} doesn't exist.");
                    }
                }

            }

            followers = followers
                .OrderByDescending(x => x.Value.Comments + x.Value.Likes)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine($"{followers.Count} followers");

            foreach (var kvp in followers)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value.Comments + kvp.Value.Likes}");
            }

        }
    }
}
