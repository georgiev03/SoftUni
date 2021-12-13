using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace _03.TakeSkipRope
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<int> numbers = new List<int>();

            foreach (var item in input)
            {
                string letter = Convert.ToString(item);
                int idx = input.IndexOf(item);
                bool success = int.TryParse(letter, out var number);
                if (success)
                {
                    numbers.Add(number);
                    input = input.Remove(idx, 1);
                }
            }

            int count = numbers.Count / 2;

            var take = new List<int>(count);
            var skip = new List<int>(count);

            for (int i = 0; i < numbers.Count; i++)
            {
                if (i % 2 == 0)
                {
                    take.Add(numbers[i]);
                }
                else
                {
                    skip.Add(numbers[i]);
                }
            }

            string result = string.Empty;
            int skipped = 0;
            for (int i = 0; i < count; i++)
            {
                int currentTake = take[i];
                int currentSkip = skip[i];

                int j = skipped;

                while (currentTake > 0 && j < input.Length)
                {
                    result += input[j++];
                    currentTake--;
                }

                skipped += currentSkip + take[i];
            }

            Console.WriteLine(result);
        }
    }
}
