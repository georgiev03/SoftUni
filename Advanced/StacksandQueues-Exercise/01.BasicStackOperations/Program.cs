using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int n = numbers[0];
            int s = numbers[1];
            int x = numbers[2];

            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> nums = new Stack<int>(input);

            for (int i = 0; i < s; i++)
            {
                nums.Pop();
            }

            if(nums.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (nums.Contains(x))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(nums.Min());
            }
        }
    }
}
