using System;
using System.Linq;

namespace _4.MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string[,] matrix = new string[size[0], size[1]];

            for (int i = 0; i < size[0]; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < size[1]; j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            while (true)
            {
                string[] tokens = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (tokens[0] == "END")
                {
                    break;
                }

                if (isValid(tokens, matrix))
                {
                    int firstRow = int.Parse(tokens[1]);
                    int firstCol = int.Parse(tokens[2]);
                    int secondRow = int.Parse(tokens[3]);
                    int secondCol = int.Parse(tokens[4]);

                    string temp = matrix[firstRow, firstCol];
                    matrix[firstRow, firstCol] = matrix[secondRow, secondCol];
                    matrix[secondRow, secondCol] = temp;

                    PrintMatrix(matrix);
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j] + " ");
                }

                Console.WriteLine();
            }
        }

        private static bool isValid(string[] tokens, string[,] matrix)
        {
            return validCommand(tokens[0]) && validLength(tokens) && validIndexes(tokens, matrix);
        }

        private static bool validIndexes(string[] tokens, string[,] matrix)
        {
            int firstRow = int.Parse(tokens[1]);
            int firstCol = int.Parse(tokens[2]);
            int secondRow = int.Parse(tokens[3]);
            int secondCol = int.Parse(tokens[4]);

            if (IsInRange(firstRow, matrix.GetLength(0)) &&
                IsInRange(firstCol, matrix.GetLength(0)) &&
                IsInRange(secondRow, matrix.GetLength(1)) &&
                IsInRange(secondCol, matrix.GetLength(1)))
            {
                return true;
            }

            return false;
        }

        private static bool IsInRange(int row, int length)
        {
            return row >= 0 && row <= length;
        }

        private static bool validLength(string[] tokens)
        {
            return tokens.Length <= 5;
        }

        private static bool validCommand(string command)
        {
            if (command == "swap")
            {
                return true;
            }

            return false;
        }
    }
}
