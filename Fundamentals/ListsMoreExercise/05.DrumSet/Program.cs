using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.DrumSet
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());

            List<int> drumsQuality = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> copy = new List<int>(drumsQuality);
            
            for (int i = 0; i < drumsQuality.Count; i++)
            {
                copy[i] = drumsQuality[i];
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Hit it again, Gabsy!")
                {
                    break;
                }

                int power = int.Parse(input);

                for (int i = 0; i < drumsQuality.Count; i++)
                {
                    drumsQuality[i] -= power;
                    if (drumsQuality[i] <= 0)
                    {
                        if (copy[i] * 3 <= budget)
                        {
                            budget -= copy[i] * 3;
                            drumsQuality[i] = copy[i];
                            continue;
                        }
                        drumsQuality.RemoveAt(i);
                        copy.RemoveAt(i);
                        i--;
                    }
                }
            }

            Console.WriteLine(string.Join(" ", drumsQuality));
            Console.WriteLine($"Gabsy has {budget:f2}lv. ");
        }
    }
}
