using System;

namespace _02.BonusPoints
{
    class Program
    {
        static void Main(string[] args)
        {
            int points = int.Parse(Console.ReadLine());
            double bonus = 0.0;
            if(points <= 100)
            {
                bonus = 5;
            }
            else if (points > 100 && points <=1000)
            {
                bonus = points * 0.2;
            }
            else if (points > 1000)
            {
                bonus = points * 0.1;
            }
            if(points % 2 == 0)
            {
                bonus += 1;
            }
            else if (points % 10 ==5)
            {
                bonus += 2;
            }
            Console.WriteLine(bonus);
            Console.WriteLine(bonus + points);
        }
    }
}
