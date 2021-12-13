using System;
using System.Linq;

namespace _2.SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            char[,] matrix = new char[size[0], size[1]];

            for (int row = 0; row < size[0]; row++)
            {
                char[] symbols = Console.ReadLine()
                    .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < size[1]; col++)
                {
                    matrix[row, col] = symbols[col];
                }
            }

            int count = 0;

            for (int row = 0; row < size[0] - 1; row++)
            {
                for (int col = 0; col < size[1] - 1; col++)
                {
                    char symbol = matrix[row, col];
                    if (symbol == matrix[row, col + 1] &&
                        symbol == matrix[row + 1, col] &&
                        symbol == matrix[row + 1, col + 1])
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);
        }
    }
}
