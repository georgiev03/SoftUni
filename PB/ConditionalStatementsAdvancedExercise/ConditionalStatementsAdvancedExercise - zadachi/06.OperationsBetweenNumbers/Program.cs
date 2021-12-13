using System;

namespace _06.OperationsBetweenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            char operation = char.Parse(Console.ReadLine());


            switch (operation)
            {
                case '+':
                    int sum = n1 + n2;
                    if (sum % 2 == 0)
                    {
                        Console.WriteLine($"{n1} + {n2} = {sum} - even");
                    }
                    else
                    {
                        Console.WriteLine($"{n1} + {n2} = {sum} - odd");
                    }
                    break;
                case '-':
                    int minus = n1 - n2;
                    if (minus % 2 == 0)
                    {
                        Console.WriteLine($"{n1} - {n2} = {minus} - even");
                    }
                    else
                    {
                        Console.WriteLine($"{n1} - {n2} = {minus} - odd");
                    }
                    break;
                case '*':
                    double multiplication = n1 * n2;
                    if (multiplication % 2 == 0)
                    {
                        Console.WriteLine($"{n1} * {n2} = {multiplication} - even");
                    }
                    else
                    {
                        Console.WriteLine($"{n1} * {n2} = {multiplication} - odd");
                    }
                    break;
                case '/':
                    double devide = n1 * 1.00 / n2;
                    if (n2 == 0)
                    {
                        Console.WriteLine($"Cannot divide {n1} by zero");
                    }
                    else
                    {
                        Console.WriteLine($"{n1} / {n2} = {devide:f2}");
                    }
                    break;
                case '%':
                    double modul = n1 *1.00 % n2;
                    if (n2 == 0)
                    {
                        Console.WriteLine($"Cannot divide {n1} by zero");
                    }
                    else
                    {
                        Console.WriteLine($"{n1} % {n2} = {modul}");
                    }
                    break;
            }
        }
    }
}
