using System;

namespace _08.LettersChangeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputs = Console.ReadLine()
                .Split(new char[]{'\t', ' '},StringSplitOptions.RemoveEmptyEntries);

            double sum = 0;

            foreach (var input in inputs)
            {
                char first = input[0];
                char last = input[^1];

                double number = double.Parse(input.Substring(1, input.Length - 2));

                if (char.IsUpper(first))
                {
                    number /= first - 64;
                }
                else
                {
                    number *= first - 96;
                }

                if (char.IsUpper(last))
                {
                    number -= last - 64;
                }
                else
                {
                    number += last - 96;
                }

                sum += number;
            }

            Console.WriteLine($"{sum:f2}");
        }
    }
}
