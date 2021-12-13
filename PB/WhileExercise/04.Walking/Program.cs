using System;

namespace _04.Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int walkedSteps = 0;
            while (walkedSteps < 10000)
            {
               string steps = Console.ReadLine();
                if (steps == "Going home")
                {
                    steps = Console.ReadLine();
                walkedSteps += int.Parse(steps);
                    if(walkedSteps >= 10000)
                    {
                       
                        break;
                    } 
                    else
                    {
                        Console.WriteLine($"{10000 - walkedSteps} more steps to reach goal.");
                        break;
                    }

                }
                walkedSteps += int.Parse(steps);
                
            }
            if (walkedSteps >= 10000)
            {
                Console.WriteLine("Goal reached! Good job!");
                Console.WriteLine($"{walkedSteps - 10000} steps over the goal!");
            }
        }
    }
}
