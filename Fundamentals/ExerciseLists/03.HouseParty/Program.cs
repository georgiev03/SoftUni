using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.HouseParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> guests = new List<string>(n);

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split();
                string name = command[0];

                if (command.Contains("not"))
                {
                    bool removed = guests.Remove(name);

                    if (!removed)
                    {
                        Console.WriteLine($"{name} is not in the list!");
                    }
                }
                else
                {
                    if (guests.Contains(name))
                    {
                        Console.WriteLine($"{name} is already in the list!");
                    }
                    else
                    {
                        guests.Add(name);
                    }
                }
            }

            foreach (string guest in guests)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
