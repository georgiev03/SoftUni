using System;

namespace _03.Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double tripMoney = double.Parse(Console.ReadLine());
            double savedMoney = double.Parse(Console.ReadLine());

            int spendCounter = 0;
            int days = 0;
            while (savedMoney < tripMoney && spendCounter < 5)
            {
                string saveOrSpend = Console.ReadLine();
                double money = double.Parse(Console.ReadLine());

                days++;
                if (saveOrSpend == "save")
                {
                    savedMoney += money;
                    spendCounter = 0;
                }

                else
                {
                    savedMoney -= money;
                    spendCounter++;
                    if(savedMoney<0)
                    {
                        savedMoney = 0;
                    }
                }
                
            }
            if(savedMoney >= tripMoney)
            {
                Console.WriteLine($"You saved the money for {days} days.");
            }
            else
            {
                Console.WriteLine("You can't save the money.");
                Console.WriteLine($"{days}");
            }

        }
    }
}
