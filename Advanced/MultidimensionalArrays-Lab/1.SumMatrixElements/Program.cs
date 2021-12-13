using System;
using System.Linq;

namespace _1.SumMatrixElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[size[0], size[1]];
            int sum = 0;

            for (int row = 0; row < size[0]; row++)
            {
                int[] numbers = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < size[1]; col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }

            foreach (var i in matrix)
            {
                sum += i;

            }

            Console.WriteLine(size[0]);
            Console.WriteLine(size[1]);
            Console.WriteLine(sum);
        }
    }
}
