using System;

namespace _05.Travelling
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();

            double sum = 0;

            while (destination != "End")
            {
                double tripCost = double.Parse(Console.ReadLine());
                while (sum < tripCost)
                {

                    sum += double.Parse(Console.ReadLine());
                    if (sum >= tripCost)
                    {
                        Console.WriteLine($"Going to {destination}!");
                        sum = 0;
                        break;
                    }
                }
                destination = Console.ReadLine();

            }

        }
    }
}
