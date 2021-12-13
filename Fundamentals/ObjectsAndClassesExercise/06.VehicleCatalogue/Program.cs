using System;
using System.Collections.Generic;

namespace _06.VehicleCatalogue
{
    class Vehicle
    {
        public string Type { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public int HorsePower { get; set; }

    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> catalog = new List<Vehicle>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "End")
                {
                    break;
                }

                string[] vehicleData = line.Split();

                string type = vehicleData[0];
                string model = vehicleData[1];
                string color = vehicleData[2];
                int hp = int.Parse(vehicleData[3]);

                Vehicle vehicle = new Vehicle
                {
                    Color = color,
                    HorsePower = hp,
                    Model = model,
                    Type = type
                };

                catalog.Add(vehicle);
            }

            while (true)
            {
                string model = Console.ReadLine();

                if (model == "Close the Catalogue")
                {
                    break;
                }

                foreach (var vehicle in catalog)
                {
                    if (vehicle.Model == model)
                    {
                        if (vehicle.Type == "car")
                        {
                            Console.WriteLine("Type: Car");
                        }
                        else
                        {
                            Console.WriteLine("Type: Truck");
                        }

                        Console.WriteLine($"Model: {vehicle.Model}");
                        Console.WriteLine($"Color: {vehicle.Color}");
                        Console.WriteLine($"Horsepower: {vehicle.HorsePower}");
                    }
                }
            }

            double avgCarHP = CalcAvgHorsePower(catalog, "car");
            double avgTruckHP = CalcAvgHorsePower(catalog, "truck");

            Console.WriteLine($"Cars have average horsepower of: {avgCarHP:f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {avgTruckHP:f2}.");
        }

        private static double CalcAvgHorsePower(List<Vehicle> catalog, string type)
        {
            int typeCount = 0;
            int typeHorsePower = 0;

            foreach (var vehicle in catalog)
            {
                if (vehicle.Type == type)
                {
                    typeCount++;
                    typeHorsePower += vehicle.HorsePower;
                }
            }

            if (typeCount == 0)
            {
                return 0;
            }

            return (double)typeHorsePower / typeCount;
        }
    }
}
