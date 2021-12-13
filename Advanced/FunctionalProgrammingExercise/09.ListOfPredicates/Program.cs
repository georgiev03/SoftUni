using System;
using System.Linq;

namespace _09.ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int range = int.Parse(Console.ReadLine());

            int[] dividers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Func<int[], int, bool> filter = (allDividers, number) =>
            {
                bool divisible = true;

                for (int i = 0; i < allDividers.Length; i++)
                {
                    if (number % allDividers[i] != 0)
                    {
                        divisible = false;
                    }
                }

                return divisible;
            };

            var numbers = Enumerable.Range(1, range)
                .Where(num => filter(dividers, num)).ToArray();

            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
