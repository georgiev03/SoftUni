using System;

namespace _06.Building
{
    class Program
    {
        static void Main(string[] args)
        {
            int floors = int.Parse(Console.ReadLine());
            int rooms = int.Parse(Console.ReadLine());

            for (int i = floors; i > 0; i--)
            {
                for (int r = 0; r < rooms; r++)
                {
                    if(i == floors)
                    {
                        Console.Write($"L{i}{r} ");
                    }
                    else if(i % 2==0)
                    {
                        Console.Write($"O{i}{r} ");
                    }
                    else
                    {
                        Console.Write($"A{i}{r} ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
