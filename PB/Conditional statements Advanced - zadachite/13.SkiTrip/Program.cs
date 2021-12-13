using System;

namespace _13.SkiTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string room = Console.ReadLine();
            string opinion = Console.ReadLine();
            int nights = days - 1;
            double price = 0.0;

            if(room == "room for one person")
            {
                price = nights * 18.00;
            }
            else if(room == "apartment")
            {
                price = nights * 25.00;
                if(days < 10)
                {
                    price *= 0.70;
                }
                else if(days >= 10 && days <= 15)
                {
                    price *= 0.65;
                }
                else if(days > 15)
                {
                    price *= 0.50;
                }
            }
            else if(room == "president apartment")
            {
                price = nights * 35.00;
                if (days < 10)
                {
                    price *= 0.90;
                }
                else if (days >= 10 && days <= 15)
                {
                    price *= 0.85;
                }
                else if (days > 15)
                {
                    price *= 0.80;
                }
            }
            if(opinion == "positive")
            {
                price = price + price * 0.25;
            }
            else if (opinion == "negative")
            {
                price = price - price * 0.10;
            }
            Console.WriteLine($"{price:f2}");
        }   
    }
}
