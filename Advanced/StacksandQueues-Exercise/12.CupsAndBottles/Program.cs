using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cupCapacity = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] bottles = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int wastedWater = 0;

            Stack<int> bottleStack = new Stack<int>(bottles);
            Queue<int> cupsQueue = new Queue<int>(cupCapacity);

            bool flag = false;

            while (!flag)
            {
                int cup = cupsQueue.Peek();

                while (cup > 0)
                {
                    int water = bottleStack.Pop();
                    cup -= water;

                    if (cup <= 0)
                    {
                        cupsQueue.Dequeue();
                    }

                    if (!bottleStack.Any())
                    {
                        Console.WriteLine($"Cups: {string.Join(' ', cupsQueue)}");
                        flag = true;
                        break;
                    }
                }

                wastedWater -= cup;

                if (!cupsQueue.Any())
                {
                    Console.WriteLine($"Bottles: {string.Join(' ', bottleStack)}");
                    flag = true;
                    break;
                }
            }

            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
