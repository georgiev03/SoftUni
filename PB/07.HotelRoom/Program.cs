using System;

namespace _07.HotelRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());
            double studio = 0;
            double apartament = 0;
            double sumStudio = 0;
            double sumApartament = 0;

            switch (month)
            {
                case "May":
                case "October":
                    studio = 50;
                    apartament = 65;
                    sumStudio = studio * nights;
                    sumApartament = apartament * nights;
                    if (nights > 7 && nights <= 14)
                    {
                        sumStudio *= 0.95;
                    }
                    else if (nights > 14)
                    {
                        sumStudio *= 0.70;
                    }
                    break;
                case "June":
                case "September":
                    studio = 75.20;
                    apartament = 68.70;
                    sumStudio = studio * nights;
                    sumApartament = apartament * nights;
                    if (nights > 14)
                    {
                        sumStudio *= 0.80;
                    }
                    break;
                case "July":
                case "August":
                    studio = 76;
                    apartament = 77;
                    sumApartament = apartament * nights;
                    sumStudio = studio * nights;
                    break;
            }
            if (nights > 14)
            {
                sumApartament *= 0.90;
            }
            Console.WriteLine($"Apartment: {sumApartament:f2} lv.");
            Console.WriteLine($"Studio: {sumStudio:f2} lv.");
        }
    }
}
