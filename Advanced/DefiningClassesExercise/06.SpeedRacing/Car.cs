using System;
using System.Collections.Generic;
using System.Text;

namespace _06.SpeedRacing
{
    public class Car
    {
        public string Model { get; set; }

        public double FuelAmount { get; set; }

        public double FuelConsPerKm { get; set; }

        public double TravelledDist { get; set; }

        public Car()
        {
            TravelledDist = 0;
        }

        public void Drive(double dist)
        {
            double fuelNeeded = dist * FuelConsPerKm;

            if (FuelAmount < fuelNeeded)
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
            else
            {
                FuelAmount -= fuelNeeded;
                TravelledDist += dist;
            }
        }
    }
}
