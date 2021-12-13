using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace _04.MixedupLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> first = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> second = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> result = new List<int>();

            bool firstIsLonger = first.Count - second.Count > 0;
            int last, penultimate;
            if (firstIsLonger)
            {
                last = first[^1];
                penultimate = first[^2];

                for (int i = 0; i < second.Count; i++)
                {
                    result.Add(first[i]);
                    result.Add(second[i]);
                }
            }
            else
            {
                last = second[^1];
                penultimate = second[^2];

                for (int i = 0; i < first.Count; i++)
                {
                    result.Add(first[i]);
                    result.Add(second[i]);
                }
            }
            int bigger = last;
            int smaller = penultimate;

            if (last < penultimate)
            {
                bigger = penultimate;
                smaller = last;
            }

            result = result.Where(n => n > smaller && n < bigger).ToList();
            result.Sort();
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
