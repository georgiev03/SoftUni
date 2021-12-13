using System;
using System.Linq;

namespace _8.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[][] matrix = new int[n][];

            for (int row = 0; row < n; row++)
            {
                int[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                matrix[row] = input;
            }

            string[] bombs = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < bombs.Length; i++)
            {
                int[] cords = bombs[i]
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                int row = cords[0];
                int col = cords[1];
                int value = matrix[row][col];

                if (value <= 0)
                {
                    continue;
                }

                Bomb(matrix, row, col, value);
            }

            int count = 0;
            int sum = 0;

            foreach (var i in matrix)
            {
                foreach (var number in i)
                {
                    if (number> 0)
                    {
                        count++;
                        sum += number;
                    }
                }
            }

            Console.WriteLine($"Alive cells: {count}");
            Console.WriteLine($"Sum: {sum}");
            foreach (var i in matrix)
            {
                Console.WriteLine(string.Join(" ", i));
            }
        }

        private static void Bomb(int[][] matrix, int row, int col, int value)
        {
            for (int i = row - 1; i <= row + 1; i++)
            {
                for (int j = col - 1; j <= col + 1; j++)
                {
                    if (CanBeBombed(matrix, i, j))
                    {
                        matrix[i][j] -= value;
                    }
                }
            }
        }

        private static bool CanBeBombed(int[][] matrix, int i, int j)
        {
            if (i >= 0 && i < matrix.GetLength(0) &&
                j >= 0 && j < matrix[i].Length)
            {
                if (matrix[i][j] > 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
