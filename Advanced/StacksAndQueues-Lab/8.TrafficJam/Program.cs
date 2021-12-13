using System;
using System.Collections.Generic;
using System.Linq;

namespace _8.TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();

            int n = int.Parse(Console.ReadLine());
            int count = 0;

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }

                if (command == "green")
                {
                    int passed = Math.Min(queue.Count, n);
                    count += passed;

                    for (int i = 0; i < passed; i++)
                    {
                        Console.WriteLine($"{queue.Dequeue()} passed!");
                    }

                }
                else
                {
                    queue.Enqueue(command);
                }
            }

            Console.WriteLine($"{count} cars passed the crossroads.");
        }
    }
}
