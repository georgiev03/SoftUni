using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace _10.Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenSecs = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());

            Queue<string> queue = new Queue<string>();
            int counter = 0;

            bool crashed = false;

            while (!crashed)
            {
                int greenTime = greenSecs;
                int lastSecs = freeWindow;
                string command = Console.ReadLine();

                if (command == "END")
                {
                    break;
                }

                if (command != "green")
                {
                    queue.Enqueue(command);
                    continue;
                }

                while (queue.Any() && greenTime > 0)
                {
                    string car = queue.Dequeue();
                    greenTime -= car.Length;
                    if (greenTime > 0)
                    {
                        counter++;
                    }
                    else
                    {
                        lastSecs += greenTime;
                        if (lastSecs < 0)
                        {
                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{car} was hit at {car[^-lastSecs]}.");
                            Environment.Exit(0);
                        }

                        counter++;
                    }
                }
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{counter} total cars passed the crossroads.");
        }
    }
}
