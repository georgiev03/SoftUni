using System;
using System.Linq;
namespace _03.RoundingNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] arr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();
            int[] rounded = new int[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                rounded[i] = (int)Math.Round(arr[i], MidpointRounding.AwayFromZero);
                if (arr[i] == 0)
                {
                    rounded[i] = 0;
                }
                Console.WriteLine($"{arr[i]} => {rounded[i]}");
            }

        }
    }
}
