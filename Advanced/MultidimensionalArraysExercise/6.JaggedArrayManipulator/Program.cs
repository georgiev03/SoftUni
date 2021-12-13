using System;
using System.Linq;
using System.Runtime.Loader;
using System.Security.Cryptography.X509Certificates;

namespace _6.JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double[][] jagged = new double[n][];

            for (int row = 0; row < n; row++)
            {
                double[] numbers = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();

                jagged[row] = numbers;

                if (row == 0)
                {
                    continue;
                }

                if (jagged[row - 1].Length == numbers.Length)
                {
                    jagged[row - 1] = jagged[row - 1]
                        .Select(x => x * 2)
                        .ToArray();

                    jagged[row] = jagged[row]
                        .Select(x => x * 2)
                        .ToArray();
                }
                else
                {
                    jagged[row - 1] = jagged[row - 1]
                        .Select(x => x / 2)
                        .ToArray();

                    jagged[row] = jagged[row]
                        .Select(x => x / 2)
                        .ToArray();
                }
            }

            while (true)
            {
                string[] tokens = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];

                if (command == "End")
                {
                    break;
                }

                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);
                int value = int.Parse(tokens[3]);

                if (!(row >= 0 && row < jagged.GetLength(0) &&
                    col >= 0 && col < jagged[row].Length))
                {
                    continue;
                }

                if (command == "Add")
                {
                    jagged[row][col] += value;
                }
                else if (command == "Subtract")
                {
                    jagged[row][col] -= value;
                }
            }

            foreach (var row in jagged)
            {
                Console.WriteLine(string.Join(' ', row));
            }

        }
    }
}
