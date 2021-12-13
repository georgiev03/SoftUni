using System;

namespace _10.RageExpenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGames = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            headsetPrice *= lostGames / 2;
            mousePrice *= lostGames / 3;
            keyboardPrice *= lostGames / 6;
            displayPrice *= lostGames / 12;

            double expenses = headsetPrice + mousePrice + keyboardPrice + displayPrice;
           Console.WriteLine($"Rage expenses: {expenses:f2} lv.");
        }
    }
}
