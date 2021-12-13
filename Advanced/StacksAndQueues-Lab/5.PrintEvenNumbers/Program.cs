using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Where(i => i % 2 == 0)
                .ToArray();

            Queue<int> numbers = new Queue<int>(nums);

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
