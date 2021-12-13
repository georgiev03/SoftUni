using System;
using System.Linq;

namespace _03.ZigZagArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] first = new int[n];
            int[] second = new int[n];
            int counter = 0;

            for (int i = 0; i < n; i++)
            {
                int[] arr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                if (counter % 2 == 0)
                {
                    first[i] = arr[0];
                    second[i] = arr[1];
                }
                else
                {
                    second[i] = arr[0];
                    first[i] = arr[1];
                }

                counter++;
            }

            Console.WriteLine(string.Join( " ", first));
            Console.WriteLine(string.Join( " ", second));
        }
    }
}
