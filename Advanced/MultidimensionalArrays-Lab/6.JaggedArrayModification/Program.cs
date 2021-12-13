using System;
using System.Linq;

namespace _6.JaggedArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] jagged = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                int[] nums = Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray();

                jagged[i] = nums;
            }

            while (true)
            {
                string[] tokens = Console.ReadLine().Split();

                if (tokens[0] == "END")
                {
                    break;
                }

                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);
                int value = int.Parse(tokens[3]);

                if(row < 0 || row >= rows || 
                   col < 0 || col >= jagged[row].Length)
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }

                if (tokens[0] == "Add")
                {
                    jagged[row][col] += value;
                }
                else
                {
                    jagged[row][col] -= value;
                }
            }

            foreach (int[] row in jagged)
            {
                Console.WriteLine(string.Join(" ", row));
            }

        }
    }
}
