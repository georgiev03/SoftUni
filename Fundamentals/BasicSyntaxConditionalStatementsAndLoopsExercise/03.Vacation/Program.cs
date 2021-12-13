using System;

namespace _03.Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            string groupType = Console.ReadLine();
            string day = Console.ReadLine();
            double price = 0;

            switch (groupType)
            {
                case "Students":
                    switch (day)
                    {
                        case "Friday":
                            price = 8.45;
                            break;
                        case "Saturday":
                            price = 9.80;
                            break;
                        case "Sunday":
                            price = 10.46;
                            break;
                    }
                    break;


                case "Business":
                    switch (day)
                    {
                        case "Friday":
                            price = 10.9;
                            break;
                        case "Saturday":
                            price = 15.6;
                            break;
                        case "Sunday":
                            price = 16;
                            break;
                    }
                    break;


                case "Regular":
                    switch (day)
                    {
                        case "Friday":
                            price = 15;
                            break;
                        case "Saturday":
                            price = 20;
                            break;
                        case "Sunday":
                            price = 22.5;
                            break;
                    }
                    break;
            }
           double finalPrice = price *people;
            switch (groupType)
            {
                case "Students":
                    if (people >= 30)
                    {
                        finalPrice *= 0.85;
                    }
                    break;

                case "Business":
                    if(people >= 100)
                    {
                        finalPrice -= price * 10;
                    }
                    break;

                case "Regular":
                    if(people >= 10 && people <= 20)
                    {
                        finalPrice *= 0.95;
                    }
                    break;
            }
            Console.WriteLine($"Total price: {finalPrice:f2}");
        }
    }
}
