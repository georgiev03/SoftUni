using System;

namespace _11.CleverLily
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double laundryPrice = double.Parse(Console.ReadLine());
            double toyPrice = double.Parse(Console.ReadLine());

            int bonusMoney = 0;
            int takenMoney = 0;
            int toys = 0;
            double money = 0.0;
            for (int i = 1; i <= age; i += 2)
            {
                toys++;
            }
            for (int i = 2; i <= age; i+= 2)
            {
                
                money += bonusMoney + 10;
                bonusMoney += 10;
                takenMoney++;
               
            }
            double toyMoney = toys * toyPrice;
            money += toyMoney - takenMoney;
            if (money >= laundryPrice)
            {
                Console.WriteLine($"Yes! {money - laundryPrice:f2}");
            }
            else
            {
                Console.WriteLine($"No! {Math.Abs(money - laundryPrice):f2}");
            }
        }
    }
}
