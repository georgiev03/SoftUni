using System;

namespace _07.CinemaTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            string movie = Console.ReadLine();
            int capacity = int.Parse(Console.ReadLine());
            int student = 0;
            int standard = 0;
            int kid = 0;
            int totalTickets = 0;

            while (movie != "Finish")
            {
                while (capacity > totalTickets)
                {
                    string ticketType = Console.ReadLine();
                    if(ticketType == "End")
                    {
                        break;
                    }
                    totalTickets++;
                    switch (ticketType)
                    {
                        case "student":
                            student++;
                            break;

                        case "standard":
                            standard++;
                            break;

                        case "kid":
                            kid++;
                            break;
                    }
                }

                Console.WriteLine($"{movie} - {1.0 * totalTickets / capacity * 100:f2}% full.");
                totalTickets = 0;
                movie = Console.ReadLine();
                if(movie == "Finish")
                {
                    break;
                }
                capacity = int.Parse(Console.ReadLine());
            }
            int allTickets = standard + student + kid;
            Console.WriteLine($"Total tickets: {allTickets}");
            Console.WriteLine($"{1.0 * student / allTickets * 100:f2}% student tickets.");
            Console.WriteLine($"{1.0 * standard / allTickets * 100:f2}% standard tickets.");
            Console.WriteLine($"{1.0 * kid / allTickets * 100:f2}% kids tickets.");
            
        }
    }
}
