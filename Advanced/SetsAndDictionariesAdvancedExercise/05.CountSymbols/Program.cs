using System;
using System.Collections.Generic;

namespace _05.CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            SortedDictionary<char, int> occurrences = new SortedDictionary<char, int>();

            foreach (var symbol in input)
            {
                if (occurrences.ContainsKey(symbol))
                {
                    occurrences[symbol]++;
                }
                else
                {
                    occurrences[symbol] = 1;
                }
            }

            foreach (var kvp in occurrences)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}
