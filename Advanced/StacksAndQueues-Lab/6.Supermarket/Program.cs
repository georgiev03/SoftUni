using System;
using System.Collections.Generic;

namespace _6.Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();

            while (true)
            {
                string customer = Console.ReadLine();

                if (customer == "End")
                {
                    break;
                }

                if (customer == "Paid")
                {
                    while (queue.Count > 0)
                    {
                        Console.WriteLine(queue.Dequeue());
                    }

                    queue.Clear();
                }
                else
                {
                    queue.Enqueue(customer);
                }
            }

            Console.WriteLine($"{queue.Count} people remaining.");
        }
    }
}
