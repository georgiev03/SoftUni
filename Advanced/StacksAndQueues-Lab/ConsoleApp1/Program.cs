using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> nums = new Stack<int>(input);

            while (true)
            {
                string[] tokens = Console.ReadLine().ToLower().Split();

                string command = tokens[0];

                if (command == "end")
                {
                    break;
                }

                if (tokens.Length == 2)
                {
                    int num = int.Parse(tokens[1]);

                    if (num > nums.Count)
                    {
                        continue;
                    }

                    for (int i = 0; i < num; i++)
                    {
                        nums.Pop();
                    }
                }
                else
                {
                    nums.Push(int.Parse(tokens[1]));
                    nums.Push(int.Parse(tokens[2]));
                }
            }


            Console.WriteLine($"Sum: {nums.Sum()}");
        }
    }
}
