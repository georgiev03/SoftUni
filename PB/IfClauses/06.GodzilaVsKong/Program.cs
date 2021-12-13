using System;

namespace _06.GodzilaVsKong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int statists = int.Parse(Console.ReadLine());
            double OutfitPriceForOne = double.Parse(Console.ReadLine());

            double outfits = statists * OutfitPriceForOne;
            double decoration = budget * 0.10;
            double expences = outfits + decoration;
            if (statists > 150)
            {
                outfits *= 0.90;
                expences = outfits + decoration;

            }
            
            if (budget >= expences)
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {budget - expences:f2} leva left.");
            }
            else
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {expences - budget:f2} leva more.");
            }
        }
    }
}
