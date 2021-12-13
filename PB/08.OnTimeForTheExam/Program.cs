using System;

namespace _08.OnTimeForTheExam
{
    class Program
    {
        static void Main(string[] args)
        {
            int examHour = int.Parse(Console.ReadLine());
            int examMinutes = int.Parse(Console.ReadLine());
            int cameHour = int.Parse(Console.ReadLine());
            int cameMinutes = int.Parse(Console.ReadLine());
            int examAllMinutes = examHour * 60 + examMinutes;
            int cameAllMinutes = cameHour * 60 + cameMinutes;

            if(examAllMinutes < cameAllMinutes)
            {
                Console.WriteLine("Late");
                int lateMins = cameAllMinutes - examAllMinutes;
                if(lateMins < 60)
                {
                    Console.WriteLine($"{lateMins} minutes after the start");
                }
                else
                {
                    int hours = lateMins / 60;
                    int mins = lateMins % 60;
                    Console.WriteLine($"{hours}:{mins:D2} hours after the start");
                }
            }
            else if(examAllMinutes == cameAllMinutes || examAllMinutes - cameAllMinutes <= 30)
            {
                Console.WriteLine("On time");
                if(examAllMinutes != cameAllMinutes)
                {
                    Console.WriteLine($"{examAllMinutes - cameAllMinutes} minutes before the start");
                }
            }
            else if(examAllMinutes - cameAllMinutes > 30)
            {
                Console.WriteLine("Early");
                int earlyMins = examAllMinutes - cameAllMinutes;
                if(earlyMins < 60)
                {
                    Console.WriteLine($"{earlyMins} minutes before the start");
                }
                else
                {
                    int hours = (earlyMins / 60);
                    int mins = earlyMins % 60;
                    Console.WriteLine($"{hours}:{mins:D2} hours before the start");
                }
                
            }

            
        }
    }
}
