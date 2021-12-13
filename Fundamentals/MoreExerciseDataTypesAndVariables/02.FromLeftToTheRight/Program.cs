using System;
using System.Linq;

namespace _02.FromLeftToTheRight
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                long sum = 0;
                long[] arr = Console.ReadLine()
                    .Split()
                    .Select(long.Parse)
                    .ToArray();
                if (arr[0] > arr[1])
                {
                    while (arr[0] > 0)
                    {
                        long lastDigit = arr[0] % 10;
                        sum += lastDigit;
                        arr[0] = arr[0] / 10;
                    }
                }
                else
                {
                    while (Math.Abs(arr[1]) > 0)
                    {
                        long lastDigit = arr[1] % 10;
                        sum += lastDigit;
                        arr[1] = arr[1] / 10;
                    }
                }

                Console.WriteLine(sum);
            }
        }
    }
}
