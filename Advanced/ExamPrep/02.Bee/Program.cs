using System;

namespace _02.Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int commands = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];
            int playerRow = 0;
            int playerCol = 0;

            for (int row = 0; row < n; row++)
            {
                string line = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = line[col];
                    if (line[col] == 'f')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }
            bool hasWon = false;
            string direction = null;

            for (int i = 0; i < commands; i++)
            {
                if (matrix[playerRow, playerCol] != 'B')
                {
                    direction = Console.ReadLine();
                    matrix[playerRow, playerCol] = '-';
                }

                if (direction == "up")
                {
                    playerRow--;
                    if (playerRow < 0)
                    {
                        playerRow = n - 1;
                    }

                    char currBlock = matrix[playerRow, playerCol];
                    if (currBlock == 'B')
                    {
                        continue;
                    }
                    if (currBlock == 'T')
                    {
                        playerRow++;
                    }
                    else if (currBlock == 'F')
                    {
                        hasWon = true;
                        break;
                    }
                }
                else if (direction == "down")
                {
                    playerRow++;
                    if (playerRow == n)
                    {
                        playerRow = 0;
                    }

                    char currBlock = matrix[playerRow, playerCol];
                    if (currBlock == 'B')
                    {
                        continue;
                    }
                    if (currBlock == 'T')
                    {
                        playerRow--;
                    }
                    else if (currBlock == 'F')
                    {
                        hasWon = true;
                        break;
                    }
                }
                else if (direction == "left")
                {
                    playerCol--;
                    if (playerCol < 0)
                    {
                        playerCol = n - 1;
                    }

                    char currBlock = matrix[playerRow, playerCol];
                    if (currBlock == 'B')
                    {
                        continue;
                    }
                    if (currBlock == 'T')
                    {
                        playerCol++;
                    }
                    else if (currBlock == 'F')
                    {
                        hasWon = true;
                        break;
                    }
                }
                else if (direction == "right")
                {
                    playerCol++;
                    if (playerCol == n)
                    {
                        playerCol = 0;
                    }

                    char currBlock = matrix[playerRow, playerCol];
                    if (currBlock == 'B')
                    {
                        continue;
                    }
                    if (currBlock == 'T')
                    {
                        playerCol--;
                    }
                    else if (currBlock == 'F')
                    {
                        hasWon = true;
                        break;
                    }
                }
            }

            matrix[playerRow, playerCol] = 'f';
            if (hasWon)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
