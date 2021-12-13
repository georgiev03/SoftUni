using System;

namespace _05.Time_15Mins
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int mins = int.Parse(Console.ReadLine());
            mins += 15;

            if(mins < 60)
            {

            }
            else if  (mins % 60 >= 0)
            {
                hours++;
                mins = 0 + mins % 60;

            }
            if(hours % 24 >=0)
            {
                hours = 0 + hours % 24;
            }
            if(mins <10)
            {
                Console.WriteLine($"{hours}:0{mins}");

            }
            else
            {
                Console.WriteLine($"{hours}:{mins}");

            }

        }
    }
}
