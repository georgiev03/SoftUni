using System;

namespace _07.WaterOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int capacity = 255;
            for (int i = 0; i < n; i++)
            {
                int litersWater = int.Parse(Console.ReadLine());
                if (litersWater > capacity)
                {
                    Console.WriteLine("Insufficient capacity!");
                    continue;
                }

                capacity -= litersWater;
            }

            Console.WriteLine(255 - capacity);
        }
    }
}
