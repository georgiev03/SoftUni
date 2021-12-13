using System;

namespace _04.MetricConventor
{
    class Program
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            string output = Console.ReadLine();
            if(input == "m")
            {
                if(output== "cm")
                {
                    Console.WriteLine($"{length * 100:f3}");
                }
                else
                {
                    Console.WriteLine($"{length * 1000:f3}");
                }
            }
            else if(input == "cm")
            {
                if (output == "m")
                {
                    Console.WriteLine($"{length / 100:f3}");
                }
                else
                {
                    Console.WriteLine($"{length * 10:f3}");
                }
            }
            else if(input =="mm")
            {
                if(output == "m")
                {
                    Console.WriteLine($"{length / 1000:f3}");
                }
                else
                {
                    Console.WriteLine($"{length / 10:f3}");

                }
            }

        }
    }
}
