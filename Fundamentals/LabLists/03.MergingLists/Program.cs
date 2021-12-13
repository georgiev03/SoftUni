using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MergingLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstNums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> secondNums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> result = new List<int>(firstNums.Count + secondNums.Count);

            int limit = Math.Min(firstNums.Count, secondNums.Count);
            int remaining = Math.Max(firstNums.Count, secondNums.Count);

            for (int i = 0; i < limit; i++)
            {
                result.Add(firstNums[i]);
                result.Add(secondNums[i]);
            }

            if (firstNums.Count != secondNums.Count)
            {
                for (int i = limit; i < remaining; i++)
                {
                    if (firstNums.Count > secondNums.Count)
                    {
                        result.Add(firstNums[i]);
                    }
                    else
                    {
                        result.Add(secondNums[i]);
                    }
                }
            }

            Console.WriteLine(string.Join( " ", result));
        }
    }
}
