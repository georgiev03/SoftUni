using System;

namespace _08.FactorialDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());

            double firstFactorial = GetFactorial(first);
            double secondFactorial = GetFactorial(second);

            double result = firstFactorial / secondFactorial;

            Console.WriteLine($"{result:f2}");
        }

        private static double GetFactorial(int num)
        {
            double factorial = 1;
            for (int i = 1; i <= num; i++)
            {
                factorial *= i;
            }

            return factorial;
        }

       
    }
}
