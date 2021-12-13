using System;
using _1.Car.CarManufacturer;

namespace _1.Car
{
    class Program
    {
        static void Main(string[] args)
        {
            var car = new Car()
            {
                Make = "VW",
                Model = "MK3",
                Year = 1992
            };

            Console.WriteLine($"Make: {car.Make}\nModel: {car.Model}\nYear: {car.Year}");
        }
    }
}
