using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Loader;

namespace _04.EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<int, int> numbers = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (numbers.ContainsKey(number))
                {
                    numbers[number]++;
                }
                else
                {
                    numbers.Add(number, 1);
                }
            }

            numbers = numbers.Where(x => x.Value % 2 == 0)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var number in numbers)
            {
                Console.WriteLine(number.Key);
            }
        }
    }
}
