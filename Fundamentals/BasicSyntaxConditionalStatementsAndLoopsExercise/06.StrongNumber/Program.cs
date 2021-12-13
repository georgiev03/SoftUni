using System;

namespace _06.StrongNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number =int.Parse(Console.ReadLine());
            int checkNum = number;
            int sum = 0;
            
            while(number > 0)
            {
                int lastDigit = number % 10;
                int multiplication = 1;
                for (int i = 1; i <= lastDigit; i++)
                {
                    multiplication *= i;
                }
                sum += multiplication;

                number /= 10;
            }
            if(sum == checkNum)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
