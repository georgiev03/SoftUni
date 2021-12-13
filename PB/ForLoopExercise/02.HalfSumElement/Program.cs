using System;

namespace _02.HalfSumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int sum = 0;
            int max = int.MinValue;

            for (int i = 0; i < n; i++)
            {
                int num2 = int.Parse(Console.ReadLine());
                sum += num2;
                if(max < num2)
                {
                    max = num2;
                }
            }
            sum -= max;
            if(max == sum)
            {
                Console.WriteLine($"Yes \nSum = " + max);
            }
            else
            {
                Console.WriteLine("No \nDiff = " + Math.Abs(sum - max));
            }
        }
    }
}
