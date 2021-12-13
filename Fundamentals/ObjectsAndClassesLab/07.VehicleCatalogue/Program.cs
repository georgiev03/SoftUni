using System;
using System.Collections.Generic;

namespace _07.VehicleCatalogue
{
    class Truck
    {
        public string Brand { get; set; }

        public string Model { get; set; }

        public int Weight { get; set; }
    }

    class Car
    {
        public string Brand { get; set; }

        public string Model { get; set; }

        public int HorsePower { get; set; }
    }

    class Catalog
    {
        public List<Car> Cars { get; set; }

        public List<Truck> Trucks { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            List<Truck> trucks = new List<Truck>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "end")
                {
                    break;
                }

                string[] tokens = line.Split('/');

                string type = tokens[0];
                string brand = tokens[1];
                string model = tokens[2];

                if (type == "Car")
                {
                    int hp = int.Parse(tokens[3]);

                    Car car = new Car
                    {
                        Brand = brand,
                        Model = model,
                        HorsePower = hp
                    };

                    cars.Add(car);
                }
                else
                {
                    int weight = int.Parse(tokens[3]);

                    Truck truck = new Truck
                    {
                        Brand = brand,
                        Model = model,
                        Weight = weight
                    };
                    trucks.Add(truck);
                }
            }

            cars.Sort((p1, p2) => string.Compare(p1.Brand, p2.Brand, StringComparison.Ordinal)); 
            trucks.Sort((p1, p2) => string.Compare(p1.Brand, p2.Brand, StringComparison.Ordinal));

            if(cars.Count > 0)
            {
                Console.WriteLine("Cars:");
                foreach (Car car in cars)
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }

            if (trucks.Count > 0)
            {
                Console.WriteLine("Trucks:");
                foreach (Truck truck in trucks)
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }
            }
        }
    }
}
