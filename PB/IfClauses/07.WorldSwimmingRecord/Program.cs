using System;

namespace _07.WorldSwimmingRecord
{
    class Program
    {
        static void Main(string[] args)
        {
            double record = double.Parse(Console.ReadLine());
            double meters = double.Parse(Console.ReadLine());
            double timeForMeter = double.Parse(Console.ReadLine());

            double time = timeForMeter * meters;
            time += Math.Floor(meters / 15) * 12.5;
            
            if(time < record)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {time:f2} seconds.");
            }
            else
            {
                Console.WriteLine($"No, he failed! He was {time - record:f2} seconds slower.");
            }
        }
    }
}