using System;

namespace _7.PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            long[][] triangle = new long[rows][];

            for (int row = 0; row < rows; row++)
            {
                triangle[row] = new long[row + 1];
                triangle[row][0] = 1;
                triangle[row][^1] = 1;
                for (int col = 1; col < row; col++)
                {
                    triangle[row][col] = triangle[row - 1][col] + triangle[row - 1][col - 1];
                }
            }

            foreach (var row in triangle)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
