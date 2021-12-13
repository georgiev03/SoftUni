using System;

namespace _08.MathPower
{
    class Program
    {
        static void Main(string[] args)
        {
            double num = double.Parse(Console.ReadLine());
            double powered = double.Parse(Console.ReadLine());
            double result = PoweredInteger(num, powered);

            Console.WriteLine(result);
        }

        static double PoweredInteger(double num, double power)
        {
            double result = 1;
            for (int i = 1; i <= power; i++)
            {
                result *= num;
            }

            return result;
        }
    }
}
