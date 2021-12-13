using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<int[]> queue = new Queue<int[]>();

            for (int i = 0; i < n; i++)
            {
                int[] petrolInfo = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                queue.Enqueue(petrolInfo);
            }

            int idx = 0;

            while (true)
            {
                int fuel = 0;

                foreach (var petrolPump in queue)
                {
                    int amount = petrolPump[0];
                    int dist = petrolPump[1];

                    fuel += amount - dist;

                    if (fuel < 0)
                    {
                        idx++;
                        queue.Enqueue(queue.Dequeue());
                        break;
                    }
                }

                if (fuel >= 0)
                {
                    break;
                }
            }

            Console.WriteLine(idx);
        }
    }
}
