using System;
using System.Linq;

namespace _05.AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Action<int[]> print = n => Console.WriteLine(string.Join(" ", n));

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }

                if (command == "add")
                {
                    numbers = ForEach(numbers, n => n + 1);
                }
                else if (command == "multiply")
                {
                    numbers = ForEach(numbers, n => n * 2);
                }
                else if (command == "subtract")
                {
                    numbers = ForEach(numbers, n => n - 1);
                }
                else if (command == "print")
                {
                    print(numbers);
                }
            }

        }

        static int[] ForEach(int[] numbers, Func<int, int> func)
            => numbers.Select(func).ToArray();
    }
}
