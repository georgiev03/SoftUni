using System;

namespace Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            string day = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());

            double milk1 = 2.50;
            double apple1 = 1.20;
            double sugar1 = 0.85;
            double orange1 = 1.45;
            double rice1 = 2.70;
            double tomato1 = 5.50;
            double salami1 = 3.85;

            double milk2 = 2.70;
            double apple2 = 1.25;
            double sugar2 = 0.90;
            double orange2 = 1.60;
            double rice2 = 3.00;
            double tomato2 = 5.60;
            double salami2 = 4.20;

            if (day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday")
            {
                if (product == "banana")
                {
                    Console.WriteLine($"{milk1 * quantity:F2}");
                }
                else if (product == "apple")
                {
                    Console.WriteLine($"{apple1 * quantity:F2}");
                }
                else if (product == "orange")
                {
                    Console.WriteLine($"{sugar1 * quantity:F2}");
                }
                else if (product == "grapefruit")
                {
                    Console.WriteLine($"{orange1 * quantity:F2}");
                }
                else if (product == "kiwi")
                {
                    Console.WriteLine($"{rice1 * quantity:F2}");
                }
                else if (product == "pineapple")
                {
                    Console.WriteLine($"{tomato1 * quantity:F2}");
                }
                else if (product == "grapes")
                {
                    Console.WriteLine($"{salami1 * quantity:F2}");
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else if (day == "Saturday" || day == "Sunday")
            {
                if (product == "banana")
                {
                    Console.WriteLine($"{ milk2 * quantity:F2}");
                }
                else if (product == "apple")
                {
                    Console.WriteLine($"{apple2 * quantity:F2}");
                }
                else if (product == "orange")
                {
                    Console.WriteLine($"{sugar2 * quantity:F2}");
                }
                else if (product == "grapefruit")
                {
                    Console.WriteLine($"{orange2 * quantity:F2}");
                }
                else if (product == "kiwi")
                {
                    Console.WriteLine($"{rice2 * quantity:F2}");
                }
                else if (product == "pineapple")
                {
                    Console.WriteLine($"{tomato2 * quantity:F2}");
                }
                else if (product == "grapes")
                {
                    Console.WriteLine($"{salami2 * quantity:F2}");
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else
            {
                Console.WriteLine("error");
            }

        }
    }
}
