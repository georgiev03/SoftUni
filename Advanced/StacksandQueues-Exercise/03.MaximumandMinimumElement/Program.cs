using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MaximumandMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<int> nums = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                int command = input[0];

                if (command == 1)
                {
                    nums.Push(input[1]);
                }
                else if (nums.Any())
                {
                    switch (command)
                    {
                        case 2:
                            nums.Pop();
                            break;
                        case 3:
                            Console.WriteLine(nums.Max());
                            break;
                        case 4:
                            Console.WriteLine(nums.Min());
                            break;
                    }
                }
            }

            Console.WriteLine(string.Join(", ", nums));
        }
    }
}
