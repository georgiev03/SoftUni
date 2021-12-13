using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.AppendArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> numbers = Console.ReadLine()
                .Split("|", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string result = "";
            
            for (int i = numbers.Count - 1; i >= 0; i--)
            {
                int[] numers = numbers[i]
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                foreach (var numer in numers)
                {
                    result += numer + " ";
                }
            }
            Console.WriteLine(result);
        }
    }
}
