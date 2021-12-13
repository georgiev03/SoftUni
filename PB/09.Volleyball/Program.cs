using System;

namespace _09.Volleyball
{
    class Program
    {
        static void Main(string[] args)
        {
            string year = Console.ReadLine();
            int holidays = int.Parse(Console.ReadLine());
            int weekends = int.Parse(Console.ReadLine());
            // holidays * 2/3 
            // 1 year = 48 weekends
            double weekendsInHome = (48 - weekends) * 3.0 / 4;
            double holidayPlays = holidays * 2.0 / 3;
            double allPlays = weekendsInHome + weekends + holidayPlays;

            if(year == "leap")
            {
                allPlays += allPlays * 0.15;
            }
            Console.WriteLine(Math.Floor(allPlays));


        }
    }
}
