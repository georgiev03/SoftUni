using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace _05.BombNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int[] line = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int specialNum = line[0];
            int radius = line[1];

            while (true)
            {
                int idx = numbers.IndexOf(specialNum);

                if (idx == -1)
                {
                    break;
                }

                int start = idx - radius;

                if (start < 0)
                {
                    start = 0;
                }

                int count = radius * 2 + 1;

                if (count > numbers.Count - start)
                {
                    count = numbers.Count - start;
                }

                numbers.RemoveRange(start, count);
            }

            int sum = 0;

            foreach (var number in numbers)
            {
                sum += number;
            }
            Console.WriteLine(sum);
        }
    }
}
