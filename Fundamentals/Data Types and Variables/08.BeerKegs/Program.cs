using System;

namespace _08.BeerKegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double biggestVolume = 0;
            string biggestModel = "";

            for (int i = 0; i < n; i++)
            {
                string model = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());
                double volume = Math.PI * radius * radius * height;
                if (volume > biggestVolume)
                {
                    biggestModel = model;
                    biggestVolume = volume;
                }
            }

            Console.WriteLine(biggestModel);
        }
    }
}
