using System;
using System.Linq;

namespace _9.Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int coals = 0;
            string[] directions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            char[,] mine = new char[n, n];
            int minerRow = 0;
            int minerCol = 0;

            for (int row = 0; row < n; row++)
            {
                char[] symbols = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < n; col++)
                {
                    mine[row, col] = symbols[col];
                    if (symbols[col] == 'c')
                    {
                        coals++;
                    }
                    else if (symbols[col] == 's')
                    {
                        minerRow = row;
                        minerCol = col;
                    }
                }
            }

            for (int i = 0; i < directions.Length; i++)
            {
                string direction = directions[i];

                if (direction == "up")
                {
                    if (CanMove(mine, minerRow - 1, minerCol))
                    {
                        minerRow--;
                        if (mine[minerRow, minerCol] == 'c')
                        {
                            mine[minerRow, minerCol] = '*';
                            coals--;
                        }
                        else if (mine[minerRow, minerCol] == 'e')
                        {
                            Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                            return;
                        }
                    }
                }
                else if (direction == "down")
                {
                    if (CanMove(mine, minerRow + 1, minerCol))
                    {
                        minerRow++;
                        if (mine[minerRow, minerCol] == 'c')
                        {
                            mine[minerRow, minerCol] = '*';
                            coals--;
                        }
                        else if (mine[minerRow, minerCol] == 'e')
                        {
                            Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                            return;
                        }
                    }
                }
                else if (direction == "left")
                {
                    if (CanMove(mine, minerRow, minerCol - 1))
                    {
                        minerCol--;
                        if (mine[minerRow, minerCol] == 'c')
                        {
                            mine[minerRow, minerCol] = '*';
                            coals--;
                        }
                        else if (mine[minerRow, minerCol] == 'e')
                        {
                            Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                            return;
                        }
                    }
                }
                else if (direction == "right")
                {
                    if (CanMove(mine, minerRow, minerCol + 1))
                    {
                        minerCol++;
                        if (mine[minerRow, minerCol] == 'c')
                        {
                            mine[minerRow, minerCol] = '*';
                            coals--;
                        }
                        else if (mine[minerRow, minerCol] == 'e')
                        {
                            Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                            return;
                        }
                    }
                }

                if (coals == 0)
                {
                    Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
                    return;
                }
            }

            Console.WriteLine($"{coals} coals left. ({minerRow}, {minerCol})");
        }

        private static bool CanMove(char[,] mine, int minerRow, int minerCol)
        {
            return minerRow >= 0 && minerRow < mine.GetLength(0) &&
                   minerCol >= 0 && minerCol < mine.GetLength(1);
        }
    }
}
