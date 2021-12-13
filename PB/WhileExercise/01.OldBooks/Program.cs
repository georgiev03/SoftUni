using System;

namespace _01.OldBooks
{
    class Program
    {
        static void Main(string[] args)
        {
            string favBook = Console.ReadLine();
            string currentBook = Console.ReadLine();
            int bookCount = 0;

            while (currentBook != favBook)
            {
                
                if(currentBook == "No More Books")
                {
                    Console.WriteLine("The book you search is not here!");
                    Console.WriteLine($"You checked {bookCount} books.");
                    break;
                }
                currentBook = Console.ReadLine();
                bookCount++;
            }
            if(favBook == currentBook)
            Console.WriteLine($"You checked {bookCount} books and found it.");
        }
    }
}
