using System;

namespace _09.LeftAndRightSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int leftSum = 0;
            int rightSum = 0;

            for (int i = 0; i < n; i++)
            {
                int leftNum = int.Parse(Console.ReadLine());
                leftSum += leftNum;
            }
            for (int i = 0; i < n; i++)
            {
                int rightNum = int.Parse(Console.ReadLine());
                rightSum += rightNum;
            }
            if(leftSum== rightSum)
            {
                Console.WriteLine("Yes, sum = " + leftSum);
            }
            else
            {
                Console.WriteLine("No, diff = " + Math.Abs(leftSum - rightSum));
            }
        }
    }
}
