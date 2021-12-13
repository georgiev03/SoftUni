using System;
using System.Collections.Generic;

namespace _08.CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var engines = new List<Engine>();

            for (int i = 0; i < n; i++)
            {
                var info = Console.ReadLine().Split();

                engines.Add(CreateEngine(info));
            }

            var m = int.Parse(Console.ReadLine());
            var cars = new List<Car>();

            for (int i = 0; i < m; i++)
            {
                var info = Console.ReadLine().Split();

                cars.Add(CreateCar(info, engines));
            }

            foreach (var car in cars)
            {
                Console.Write(car.ToString());
            }
        }

        private static Car CreateCar(string[] info, List<Engine> engines)
        {
            var carModel = info[0];
            var engineModel = info[1];
            var engine = engines.Find(e => e.Model == engineModel);

            var car = new Car(carModel, engine);

            if (info.Length > 2)
            {
                var isDigit = int.TryParse(info[2], out int weight);

                if (isDigit)
                {
                    car.Weight = weight;
                }
                else
                {
                    car.Color = info[2];
                }
            }

            if (info.Length > 3)
            {
                car.Color = info[3];
            }

            return car;
        }

        private static Engine CreateEngine(string[] info)
        {
            Engine engine = new Engine(info[0], int.Parse(info[1]));

            if (info.Length > 2)
            {
                var isDigit = int.TryParse(info[2], out int displacement);

                if (isDigit)
                {
                    engine.Displacement = displacement;
                }
                else
                {
                    engine.Efficiency = info[2];
                }

                if (info.Length > 3)
                {
                    engine.Efficiency = info[3];
                }
            }


            return engine;
        }
    }
}
