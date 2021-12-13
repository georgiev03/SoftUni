using System;
using System.Linq;

namespace _5.SquareWithMaximumSum
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

            int maxSum = int.MinValue;
            int maxRow = 0;
            int maxCol = 0;

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

            for (int row = 0; row < size[0] - 1; row++)
            {
                for (int col = 0; col < size[1] - 1; col++)
                {
                    int sum = matrix[row, col] + matrix[row, col + 1] +
                              matrix[row + 1, col] + matrix[row + 1, col + 1];

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        maxCol = col;
                        maxRow = row;
                    }
                }
            }

            Console.WriteLine(matrix[maxRow, maxCol] + " " + matrix[maxRow, maxCol + 1]);
            Console.WriteLine(matrix[maxRow + 1, maxCol] + " " + matrix[maxRow + 1, maxCol + 1]);
            Console.WriteLine(maxSum);
        }
    }
}
