using System;

namespace _05.Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string place = "";
            double moneySpent = 0;
            string destination = "";

            if(budget <= 100)
            {
                destination = "Bulgaria";
                switch(season)
                {
                    case "summer":
                        moneySpent = budget * 0.30;
                        place = "Camp";
                        break;
                    case "winter":
                        moneySpent = budget * 0.70;
                        place = "Hotel";
                        break;
                }
            }
            else if(budget <= 1000 && budget > 100)
            {
                destination = "Balkans";
                switch (season)
                {
                    case "summer":
                        moneySpent = budget * 0.40;
                        place = "Camp";
                        break;
                    case "winter":
                        moneySpent = budget * 0.80;
                        place = "Hotel";
                        break;
                }
            }
            else if(budget > 1000)
            {
                destination = "Europe";
                switch (season)
                {
                    case "summer":
                        moneySpent = budget * 0.90;
                        place = "Hotel";
                        break;
                    case "winter":
                        moneySpent = budget * 0.90;
                        place = "Hotel";
                        break;
                }
            }

            Console.WriteLine($"Somewhere in {destination}" );
            Console.WriteLine($"{place} - {moneySpent:f2}");
        }
    }
}
