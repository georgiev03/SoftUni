using System;
using System.Linq;

namespace _2.SumMatrixColumns
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

            for (int row = 0; row < size[0]; row++)
            {
                int[] numbers = Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < size[1]; col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }

            for (int col = 0; col < size[1]; col++)
            {
                int sum = 0;

                for (int row = 0; row < size[0]; row++)
                {
                    sum += matrix[row, col];
                }

                Console.WriteLine(sum);
            }

        }
    }
}
