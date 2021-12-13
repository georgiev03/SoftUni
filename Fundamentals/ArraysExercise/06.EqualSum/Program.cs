using System;
using System.Linq;

namespace _06.EqualSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            bool isEqual = false;

            for (int i = 0; i < arr.Length; i++)
            {
                int leftSum = 0;

                for (int j = i - 1; j >= 0; j--)
                {
                    leftSum += arr[j];
                }

                int rightSum = 0;

                for (int j = i + 1; j < arr.Length; j++)
                {
                    rightSum += arr[j];
                }

                if (leftSum == rightSum)
                {
                    Console.WriteLine($"{i}");
                    isEqual = true;
                    break;
                }
            }

            if (!isEqual)
            {
                Console.WriteLine("no");
            }
        }
    }
}
