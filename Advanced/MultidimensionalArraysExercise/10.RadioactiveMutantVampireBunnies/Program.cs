using System;
using System.Linq;

namespace _10.RadioactiveMutantVampireBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int playerRow = 0;
            int playerCol = 0;

            char[,] field = new char[size[0], size[1]];

            for (int i = 0; i < size[0]; i++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int j = 0; j < size[1]; j++)
                {
                    field[i, j] = input[j];
                    if(input[j] == 'P')
                    {
                        playerRow = i;
                        playerCol = j;
                    }
                }
            }

            string commands = Console.ReadLine();

            foreach (var command in commands)
            {
                if (command == 'U')
                {
                    if (CanMove(field, playerRow - 1, playerCol))
                    {
                        playerRow--;
                        
                        
                    }
                }
            }
        }

        private static bool CanMove(char[,] field, int playerRow, int playerCol)
        {
            return playerRow >= 0 && playerRow < field.GetLength(0) &&
                   playerCol >= 0 && playerCol < field.GetLength(1);
        }
    }
}
