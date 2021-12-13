using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Loader;

namespace _01.Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> passangers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int maxPassangers = int.Parse(Console.ReadLine());

            while (true)
            {
                string[] line = Console.ReadLine().Split();
                if (line[0] == "end")
                {
                    break;
                }

                if (line[0] == "Add")
                {
                    int addedPassengers = int.Parse(line[1]);
                    passangers.Add(addedPassengers);
                }
                else
                {
                    int passengersToAdd = int.Parse(line[0]);

                    for (int i = 0; i < passangers.Count; i++)
                    {
                        if (passangers[i] + passengersToAdd <= maxPassangers)
                        {
                            passangers[i] += passengersToAdd;
                            break;
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(" ", passangers));
        }
    }
}
