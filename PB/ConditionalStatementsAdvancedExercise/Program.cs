using System;

namespace ConditionalStatementsAdvancedExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            string projection = Console.ReadLine();
            int r = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            double places = r * c;
            double price = places;
            switch(projection)
            {
                case "Premiere":
                    price *= 12.00;
                    break;
                case "Normal":
                    price *= 7.50;
                    break;
                case "Discount":
                    price *= 5.00;
                    break;
            }
            Console.WriteLine($"{price:f2} leva");
        }
    }
}
