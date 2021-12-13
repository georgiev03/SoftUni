using System;

namespace _09.Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int w = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());
            int h = int.Parse(Console.ReadLine());
            string box = Console.ReadLine();
            int room = w * l * h;
            int boxSum = 0;

            while (true)
            {
                if(box == "Done")
                {
                    Console.WriteLine($"{room - boxSum} Cubic meters left.");
                    break;
                }
                
                boxSum += int.Parse(box);
                if (room <= boxSum)
                {
                    Console.WriteLine($"No more free space! You need {boxSum - room} Cubic meters more.");
                    break;
                }

                box = Console.ReadLine();
            }

        }
    }
}
