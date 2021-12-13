using System;
using System.Collections.Generic;

namespace _06.SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(", ");

            Queue<string> songsQueue = new Queue<string>(input);

            while (songsQueue.Count > 0)
            {
                string command = Console.ReadLine();

                if (command.Contains("Play"))
                {
                    songsQueue.Dequeue();
                }
                else if (command.Contains("Add"))
                {
                    string song = command.Substring(4);

                    if (songsQueue.Contains(song))
                    {
                        Console.WriteLine($"{song} is already contained!");
                        continue;
                    }

                    songsQueue.Enqueue(song);
                }
                else
                {
                    Console.WriteLine(string.Join(", ",songsQueue));
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
