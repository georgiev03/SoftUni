using System;

namespace _10.OddEvenSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int oddSum = 0;
            int evenSum = 0;

            for (int i = 1; i <= n; i++)
            {
                int num2 = int.Parse(Console.ReadLine());
                if(i % 2 == 0)
                {
                    evenSum += num2;
                }
                else
                {
                    oddSum += num2;
                }
            }
            if(evenSum == oddSum)
            {
                Console.WriteLine("Yes \nSum = "  + evenSum);
            }
            else
            {
                Console.WriteLine("No \nDiff = " + Math.Abs(evenSum - oddSum));
            }
        }
    }
}
