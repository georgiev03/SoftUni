using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split()
                .Reverse()
                .ToArray();

            Stack<string> calc = new Stack<string>(input);

            while (calc.Count > 1)
            {
                int a = int.Parse(calc.Pop());
                string oper = calc.Pop();
                int b = int.Parse(calc.Pop());

                if (oper == "+")
                {
                    calc.Push(a + b + "");
                }
                else
                {
                    calc.Push(a - b + "");
                }
            }

            Console.WriteLine(calc.Pop());
        }
    }
}
