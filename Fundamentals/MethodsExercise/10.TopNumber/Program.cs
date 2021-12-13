using System;

namespace _10.TopNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i < number; i++)
            {
                if (IsTopNumber(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        private static bool IsTopNumber(int currentNum)
        {
            return IsDevisibleBy(currentNum, 8) && HasOddDigit(currentNum);
        }

        private static bool HasOddDigit(int currentNum)
        {
            while (currentNum != 0)
            {
                int lastDigit = currentNum % 10;
                if (lastDigit % 2 != 0)
                {
                    return true;
                }
                currentNum /= 10;
            }

            return false;
        }

        private static bool IsDevisibleBy(int currentNum, int divider)
        {
            int sum = 0;
            while (currentNum != 0)
            {
                sum += currentNum % 10;
                currentNum /= 10;
            }

            if (sum % divider == 0)
            {
                return true;
            }

            return false;
        }
    }
}
