using System;

namespace _02.AsciiSumator
{
    class Program
    {
        static void Main(string[] args)
        {
            char first = char.Parse(Console.ReadLine());
            char second = char.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            int sum = 0;

            int min = Math.Min(first, second);
            int max = Math.Max(first, second);

            foreach (var symbol in input)
            {
                if (symbol > min && symbol < max)
                {
                    sum += symbol;
                }
            }

            Console.WriteLine(sum);

        }
    }
}
