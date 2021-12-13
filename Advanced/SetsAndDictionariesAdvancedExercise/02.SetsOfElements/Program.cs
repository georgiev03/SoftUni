using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            HashSet<string> n = new HashSet<string>();
            HashSet<string> m = new HashSet<string>();

            for (int i = 0; i < sizes[0]; i++)
            {
                n.Add(Console.ReadLine());
            }

            for (int i = 0; i < sizes[0]; i++)
            {
                m.Add(Console.ReadLine());
            }

            CheckSets(n, m);

        }

        private static void CheckSets(HashSet<string> hashSet, HashSet<string> hashSet1)
        {
            List<int> result = new List<int>();

            foreach (var number in hashSet)
            {
                if (hashSet1.Contains(number))
                {
                    result.Add(int.Parse(number));
                }
            }

            Console.WriteLine(string.Join(' ', result));

        }
    }
}
