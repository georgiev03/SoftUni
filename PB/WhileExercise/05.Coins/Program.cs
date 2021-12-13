using System;

namespace _05.Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            double change = double.Parse(Console.ReadLine());
            int coins = 0;
            while (change > 0)
            {
            change = Math.Round(change , 2);
                if(change >= 2)
                {
                    change -= 2.0;
                }
                else if(change >= 1)
                {
                    change -= 1.0;
                }
                else if (change >= 0.50)
                {
                    change -= 0.50;
                }
                else if (change >= 0.20)
                {
                    change -= 0.20;
                }
                else if (change >= 0.10)
                {
                    change -= 0.10;
                }
                else if (change >= 0.05)
                {
                    change -= 0.05;
                }
                else if (change >= 0.02)
                {
                    change -= 0.02;
                }
                else if (change >= 0.01)
                {
                    change -= 0.01;
                }
                coins++;
                
            }
            Console.WriteLine(coins);
        }
    }
}
