using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.SpeedRacing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split();
                string model = line[0];
                double fuelAmount = double.Parse(line[1]);
                double fuelConsPerKm = double.Parse(line[2]);

                Car car = new Car
                {
                    Model = model,
                    FuelAmount = fuelAmount,
                    FuelConsPerKm = fuelConsPerKm
                };

                cars.Add(car);
            }

            while (true)
            {
                string[] line = Console.ReadLine().Split();

                if (line[0] == "End")
                {
                    break;
                }

                string model = line[1];
                double dist = double.Parse(line[2]);

                cars.Where(c => c.Model == model).ToList().ForEach(c => c.Drive(dist));
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDist}");
            }
        }
    }
}
