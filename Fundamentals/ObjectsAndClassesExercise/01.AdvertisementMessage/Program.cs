using System;
using System.Collections.Generic;

namespace _01.AdvertisementMessage
{


    class Program
    {
        static void Main(string[] args)
        {
            string[] phrases = new[]
            {
                "Excellent product.",
                "Such a great product.",
                "I always use that product.",
                "Best product of its category.",
                "Exceptional product.",
                "I can’t live without this product."
            };

            string[] events = new[]
            {
                "Now I feel good.",
                "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.",
                "I feel great!"
            };

            string[] authors = new[] { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };

            string[] cities = new[] { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

            Random rdm = new Random();

            int messages = int.Parse(Console.ReadLine());

            for (int i = 0; i < messages; i++)
            {
                int phraseIdx = rdm.Next(phrases.Length);
                int eventIdx = rdm.Next(events.Length);
                int authorIdx = rdm.Next(authors.Length);
                int cityIdx = rdm.Next(cities.Length);

                string message = $"{phrases[phraseIdx]} {events[eventIdx]} {authors[authorIdx]} – {cities[cityIdx]}";

                Console.WriteLine(message);
            }

        }
    }
}
