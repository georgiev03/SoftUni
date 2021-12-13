using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantity = int.Parse(Console.ReadLine());

            int[] orders = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>(orders);

            bool hasFood = true;

            Console.WriteLine(queue.Max());

            while (queue.Count > 0)
            {
                if (quantity >= queue.Peek())
                {
                    quantity -= queue.Dequeue();
                }
                else
                {
                    hasFood = false;
                    break;
                }
            }

            if (hasFood)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ", queue)}");
            }
        }
    }
}
