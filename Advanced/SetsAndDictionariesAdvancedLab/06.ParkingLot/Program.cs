using System;
using System.Collections.Generic;

namespace _06.ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> cars = new HashSet<string>();

            while (true)
            {
                string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "END")
                {
                    break;
                }

                if (input[0] == "IN")
                {
                    cars.Add(input[1]);
                }
                else
                {
                    cars.Remove(input[1]);
                }
            }

            if (cars.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
