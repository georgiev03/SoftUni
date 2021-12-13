using System;

namespace _02.CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            int result = MultiplyBoth(input[0], input[1]);

            Console.WriteLine(result);
        }

        private static int MultiplyBoth(string first, string second)
        {
            int minLength = Math.Min(first.Length, second.Length);

            int sum = 0;

            for (int i = 0; i < minLength; i++)
            {
                sum += first[i] * second[i];
            }

            if (first.Length > second.Length)
            {
                sum += GetRemindingSum(first, minLength);
            }
            else if (second.Length > first.Length)
            {
                sum += GetRemindingSum(second, minLength);
            }

            return sum;
        }

        private static int GetRemindingSum(string word, int idx)
        {
            int sum = 0;

            for (int i = idx; i < word.Length; i++)
            {
                sum += word[i];
            }

            return sum;
        }
    }
}
