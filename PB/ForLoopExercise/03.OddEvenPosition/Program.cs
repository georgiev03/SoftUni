using System;

namespace _03.OddEvenPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double sumEven = 0;
            double minOdd = 1000000000.0;
            double maxOdd = -1000000000.0;
            double maxEven = -1000000000.0;
            double minEven = 1000000000.0;
            double sumOdd = 0;
            for (int i = 1; i <= n; i++)
            {
                double num2 = double.Parse(Console.ReadLine());
                
                if (i % 2 == 0)
                {
                    sumEven += num2;
                    if (minEven > num2)
                    {
                        minEven = num2;
                    }
                    if (maxEven < num2)
                    {
                        maxEven = num2;
                    }
                }
                else
                {
                    sumOdd += num2;
                    if (minOdd > num2)
                    {
                        minOdd = num2;
                    }
                    if (maxOdd < num2)
                    {
                        maxOdd = num2;
                    }
                }
            }
            Console.WriteLine($"OddSum={sumOdd:f2},");
            if (minOdd == 1000000000.0 && maxOdd == -1000000000.0)
            {
                Console.WriteLine("OddMin=No,");
                Console.WriteLine("OddMax=No,");
            }
            else
            {
                Console.WriteLine($"OddMin={minOdd:f2},");
                Console.WriteLine($"OddMax={maxOdd:f2},");
            }
            Console.WriteLine($"EvenSum={sumEven:f2},");
            if (minEven == 1000000000.0 && maxEven == -1000000000.0)
            {
                Console.WriteLine("EvenMin=No,");
                Console.WriteLine("EvenMax=No");
            }
            else
            {
                Console.WriteLine($"EvenMin={minEven:f2},");
                Console.WriteLine($"EvenMax={maxEven:f2}");
            }
        }
    }
}
