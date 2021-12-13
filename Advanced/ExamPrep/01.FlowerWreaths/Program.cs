using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.FlowerWreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstLine = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int[] secondLine = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> bombEffect = new Queue<int>(firstLine);
            Stack<int> bombCast = new Stack<int>(secondLine);

            int datura = 0;
            int cherry = 0;
            int smokes = 0;

            bool filled = false;
            while (bombCast.Any() && bombEffect.Any() && !filled)
            {
                int currBomb = bombEffect.Peek();
                int currCast = bombCast.Pop();

                int sum = currCast + currBomb;

                if (sum == 120)
                {
                    smokes++;
                    bombEffect.Dequeue();
                }
                else if (sum == 60)
                {
                    bombEffect.Dequeue();
                    cherry++;
                }
                else if (sum == 40)
                {
                    bombEffect.Dequeue();
                    datura++;
                }
                else
                {
                    bombCast.Push(currCast - 5);
                }

                filled = datura >= 3 && cherry >= 3 && smokes >= 3;

            }


            if (filled)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (!bombEffect.Any())
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", bombEffect)}");
            }

            if (!bombCast.Any())
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", bombCast)}");
            }

            Console.WriteLine($"Cherry Bombs: {cherry}");
            Console.WriteLine($"Datura Bombs: {datura}");
            Console.WriteLine($"Smoke Decoy Bombs: {smokes}");
        }
    }
}
