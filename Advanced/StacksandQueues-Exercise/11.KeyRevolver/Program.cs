using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int barrelSize = int.Parse(Console.ReadLine());
            int[] bullets = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[] locks = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int intelligenceValue = int.Parse(Console.ReadLine());

            Queue<int> locksQueue = new Queue<int>(locks);
            Stack<int> bulletsStack = new Stack<int>(bullets);

            int shots = 0;

            while (true)
            {

                int bullet = bulletsStack.Pop();
                shots++;

                if (bullet <= locksQueue.Peek())
                {
                    Console.WriteLine("Bang!");
                    locksQueue.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                if (shots % barrelSize == 0 && bulletsStack.Any())
                {
                    Console.WriteLine("Reloading!");
                }

                if (!locksQueue.Any())
                {
                    break;
                }

                if (!bulletsStack.Any())
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {locksQueue.Count}");
                    return;
                }

            }

            Console.WriteLine($"{bulletsStack.Count} bullets left. Earned ${intelligenceValue - shots * bulletPrice}");

        }
    }
}
