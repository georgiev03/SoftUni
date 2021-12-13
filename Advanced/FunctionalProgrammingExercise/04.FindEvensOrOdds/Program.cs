using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            var boundaries = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string query = Console.ReadLine();

            Predicate<int> predicate = query == "odd"
                ? n => n % 2 != 0
                : new Predicate<int>(n => n % 2 == 0);

            List<int> result = new List<int>();

            for (int i = boundaries[0]; i <= boundaries[1]; i++)
            {
                if (predicate(i))
                {
                    result.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
