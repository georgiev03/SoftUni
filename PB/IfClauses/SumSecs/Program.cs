using System;

namespace SumSecs
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstTime = int.Parse(Console.ReadLine());
            int secondTime = int.Parse(Console.ReadLine());
            int thirdTime = int.Parse(Console.ReadLine());
            
            int totalTime = firstTime + secondTime + thirdTime;

            int mins = totalTime / 60;
            int secs = totalTime % 60;
            if (secs < 10)
            {
                Console.WriteLine($"{mins}:0{secs}");
            }
            else
            {
                Console.WriteLine($"{mins}:{secs}");
            }



        }
    }
}
