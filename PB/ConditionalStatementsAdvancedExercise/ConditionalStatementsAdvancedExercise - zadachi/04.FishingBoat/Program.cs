using System;

namespace _04.FishingBoat
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fishermans = int.Parse(Console.ReadLine());
            double price = 0;
            double discount = 0;

            switch(season)
            {
                case "Spring":
                    price = 3000;
                    break;
                case "Summer":
                case "Autumn":
                    price = 4200;
                    break;
                case "Winter":
                    price = 2600;
                    break;
            }
            if(fishermans <= 6)
            {
                discount = 0.10;
            }
            else if(fishermans >= 7 && fishermans <= 11)
            {
                discount = 0.15;
            }
            else if(fishermans >= 12)
            {
                discount = 0.25;
            }
            price -= (price * discount);

            if (fishermans % 2 == 0 && season != "Autumn")
            {
                price *= 0.95;
            }
            

            double moneyLeft = budget - price;
            if(budget >= price)
            {
                Console.WriteLine($"Yes! You have {moneyLeft:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {Math.Abs(moneyLeft):f2} leva.");
            }

        }
    }
}
