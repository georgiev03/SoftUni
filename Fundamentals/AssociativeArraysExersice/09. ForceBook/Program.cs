using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> book = new Dictionary<string, List<string>>();

            Dictionary<string, string> members = new Dictionary<string, string>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Lumpawaroo")
                {
                    break;
                }

                if (input.Contains("|"))
                {
                    string[] tokens = input.Split(" | ");


                    string side = tokens[0];
                    string user = tokens[1];

                    if (!members.ContainsKey(user))
                    {
                        if (book.ContainsKey(side))
                        {
                            book[side].Add(user);
                        }
                        else
                        {
                            book.Add(side, new List<string> { user });
                        }

                        members.Add(user, side);
                    }
                }
                else
                {
                    string[] tokens = input.Split(" -> ");

                    string user = tokens[0];
                    string side = tokens[1];

                    if (members.ContainsKey(user))
                    {
                        string oldSide = members[user];
                        members.Remove(user);
                        book[oldSide].Remove(user);

                        if (book.ContainsKey(side))
                        {
                            book[side].Add(user);
                        }
                        else
                        {
                            book.Add(side, new List<string> { user });
                        }

                        members.Add(user, side);
                    }
                    else
                    {
                        if (book.ContainsKey(side))
                        {
                            book[side].Add(user);
                        }
                        else
                        {
                            book.Add(side, new List<string> { user });
                        }

                        members.Add(user, side);
                    }

                    Console.WriteLine($"{user} joins the {side} side!");
                }
            }

            var sortedBook = book
                .OrderByDescending(u => u.Value.Count)
                .ThenBy(n => n.Key);

            foreach (var kvp in sortedBook)
            {
                if (kvp.Value.Count > 0)
                {
                    Console.WriteLine($"Side: {kvp.Key}, Members: {kvp.Value.Count}");

                    foreach (var user in kvp.Value.OrderBy(n => n))
                    {
                        Console.WriteLine($"! {user}");
                    }
                }
            }
        }
    }
}
