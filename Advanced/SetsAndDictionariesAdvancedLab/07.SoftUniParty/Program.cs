using System;
using System.Collections.Generic;

namespace _07.SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> guests = new HashSet<string>();

            while (true)
            {
                string list = Console.ReadLine();

                if (list == "PARTY")
                {
                    break;
                }

                guests.Add(list);
            }

            while (true)
            {
                string came = Console.ReadLine();

                if (came == "END")
                {
                    break;
                }

                guests.Remove(came);
            }

            Console.WriteLine(guests.Count);
            foreach (var guest in guests)
            {
                if (char.IsDigit(guest[0]))
                    Console.WriteLine(guest);
            }

            foreach (var guest in guests)
            {
                if (char.IsLetter(guest[0]))
                {
                    Console.WriteLine(guest);
                }
            }
        }
    }
}
