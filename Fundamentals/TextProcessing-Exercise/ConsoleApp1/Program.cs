using System;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            int multiplier = int.Parse(Console.ReadLine());

            Console.WriteLine(MultiplyBigNumbers(number, multiplier));
        }

        private static string MultiplyBigNumbers(string number, int multiplier)
        {
            if (multiplier == 0)
            {
                return "0";
            }

            int remainder = 0;

            StringBuilder result = new StringBuilder();

            for (int i = number.Length - 1; i >= 0; i--)
            {
                int currDigit = number[i] - '0';

                remainder += currDigit * multiplier;

                if (remainder > 9)
                {
                    result.Append(remainder % 10);
                    remainder /= 10;
                }
                else
                {
                    result.Append(remainder);
                    remainder = 0;
                }
            }

            if (remainder > 0)
            {
                result.Append(remainder);
            }

            return string.Concat(result.ToString().Reverse());
        }
    }
}
