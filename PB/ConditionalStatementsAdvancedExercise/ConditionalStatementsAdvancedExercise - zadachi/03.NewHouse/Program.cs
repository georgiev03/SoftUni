using System;

namespace _03.NewHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            string flower = Console.ReadLine();
            int flowersCount = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());
            double price = 0;

            if (flower == "Roses")
            {
                price = flowersCount * 5;
                if (flowersCount > 80)
                {
                    price *= 0.90;
                }
            }
            else if (flower == "Dahlias")
            {
                price = flowersCount * 3.80;
                if (flowersCount > 90)
                {
                    price *= 0.85;
                }
            }
            else if (flower == "Tulips")
            {
                price = flowersCount * 2.80;
                if (flowersCount > 80)
                {
                    price *= 0.85;
                }
            }
            else if (flower == "Narcissus")
            {
                price = flowersCount * 3;
                if (flowersCount < 120)
                {
                    price = price + price * 0.15;
                }
            }
            else if (flower == "Gladiolus")
            {
                price = flowersCount * 2.50;
                if(flowersCount < 80)
                {
                    price = price + price * 0.20;
                }
            }
            double moneyLeft = budget - price;
            if(budget >= price)
            {
                Console.WriteLine($"Hey, you have a great garden with {flowersCount} {flower} and {moneyLeft:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {Math.Abs(moneyLeft):f2} leva more.");
            }
        }
    }
}
