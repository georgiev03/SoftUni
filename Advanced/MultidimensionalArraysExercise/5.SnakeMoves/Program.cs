using System;
using System.Linq;
using System.Text;

namespace _5.SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string snake = Console.ReadLine();

            for (int row = 0; row < size[0]; row++)
            {
                StringBuilder sb = new StringBuilder();

                for (int col = 0; col < size[1]; col++)
                {
                    if (row % 2 == 0)
                    {
                        sb.Append(snake[col]);
                    }
                    else
                    {
                        var index = col+1;
                        sb.Append(snake[^index]);
                    }
                }

                snake = sb.ToString();
                Console.WriteLine(sb);
            }
        }
    }
}
