using System;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            double tripPrice = double.Parse(Console.ReadLine());
            int puzzles = int.Parse(Console.ReadLine());
            int dolls = int.Parse(Console.ReadLine());
            int bears = int.Parse(Console.ReadLine());
            int minions = int.Parse(Console.ReadLine());
            int trucks = int.Parse(Console.ReadLine());

            double puzzlePrice = 2.60;
            double dollPrice = 3;
            double bearPrice = 4.10;
            double minionPrice = 8.20;
            double truckPrice = 2;

            double allMoney = puzzles * puzzlePrice + dolls * dollPrice + bears * bearPrice + minions * minionPrice + trucks * truckPrice;
            double allToys = puzzles + dolls + bears + minions + trucks;
            if (allToys >= 50)
            {
                allMoney = allMoney * 0.75;
            }
            allMoney = allMoney * 0.90;
            if (tripPrice <= allMoney)
            {
                allMoney = allMoney - tripPrice;
                Console.WriteLine($"Yes! {allMoney:F2} lv left.");
            }
            else if (tripPrice > allMoney)
            {
                allMoney = tripPrice - allMoney;
                Console.WriteLine($"Not enough money! {allMoney:F2} lv needed.");
            }
        }



    }
}
