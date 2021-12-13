using System;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using BookShop.Models;
using BookShop.Models.Enums;
using Castle.DynamicProxy.Generators;
using Microsoft.EntityFrameworkCore;

namespace BookShop
{
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            //string cmd = Console.ReadLine();
            // int asd = int.Parse(Console.ReadLine());
            Console.WriteLine(RemoveBooks(db));
        }

        //Problem 1
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var sb = new StringBuilder();

            var ageRestriction = Enum.Parse<AgeRestriction>(command, true);

            var books = context
                .Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList();

            foreach (var b in books)
            {
                sb.AppendLine(b);
            }

            return sb.ToString().Trim();
        }

        //Problem 2
        public static string GetGoldenBooks(BookShopContext context)
        {
            var sb = new StringBuilder();

            var goldenBooks = context
                .Books
                .Where(b => b.EditionType == EditionType.Gold)
                .Where(b => b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            foreach (var book in goldenBooks)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().Trim();
        }

        //Problem 3
        public static string GetBooksByPrice(BookShopContext context)
        {
            var sb = new StringBuilder();

            var books = context
                .Books
                .Where(b => b.Price > 40)
                .Select(b => new
                {
                    b.Title,
                    b.Price
                })
                .OrderByDescending(b => b.Price)
                .ToArray();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:f2}");
            }

            return sb.ToString().Trim();
        }

        //Problem 4
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var sb = new StringBuilder();

            var notReleasedBooks = context
                .Books
                .Where(b => b.ReleaseDate.HasValue && b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            foreach (var book in notReleasedBooks)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().Trim();
        }

        //Problem 5
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var sb = new StringBuilder();

            var categories = input.ToLower().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var books = context
                .BooksCategories
                .Select(bc => new
                {
                    BookTitle = bc.Book.Title,
                    Category = bc.Category.Name
                })
                .Where(b => categories.Contains(b.Category.ToLower()))
                .OrderBy(b => b.BookTitle)
                .ToArray();

            foreach (var book in books)
            {
                sb.AppendLine(book.BookTitle);
            }

            return sb.ToString().Trim();
        }

        //Problem 6
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var sb = new StringBuilder();

            var dateParsed = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context
                .Books
                .Where(b => b.ReleaseDate < dateParsed)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    Title = b.Title,
                    Edition = b.EditionType,
                    Price = $"${b.Price:f2}"
                });
            foreach (var b in books)
            {
                sb.AppendLine($"{b.Title} - {b.Edition} - {b.Price}");
            }

            return sb.ToString().Trim();
        }

        //Problem 7
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var sb = new StringBuilder();

            var books = context
                .Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => a.FirstName + " " + a.LastName)
                .OrderBy(a => a)
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().Trim();
        }

        //Problem 8
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var sb = new StringBuilder();

            var books = context
                .Books
                .ToArray()
                .Where(b => b.Title.Contains(input, StringComparison.InvariantCultureIgnoreCase))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToArray();

            foreach (var book in books)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().Trim();
        }

        //Problem 9
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var sb = new StringBuilder();

            var books = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(x => new
                {
                    x.Title,
                    AuthorName = $"{x.Author.FirstName} {x.Author.LastName}"
                })
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} ({book.AuthorName})");
            }

            return sb.ToString().Trim();
        }

        //Problem 10
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            return context
                .Books
                .Count(b => b.Title.Length > lengthCheck);
        }

        //Problem 11
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var sb = new StringBuilder();

            var copies = context
                .Authors
                .Select(a => new
                {
                    AuthorName = a.FirstName + " " + a.LastName,
                    Copies = a.Books.Sum(c => c.Copies)
                })
                .OrderByDescending(b => b.Copies)
                .ToArray();

            foreach (var copy in copies)
            {
                sb.AppendLine($"{copy.AuthorName} - {copy.Copies}");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 12
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var sb = new StringBuilder();

            var categories = context
                .Categories
                .Select(c => new
                {
                    c.Name,
                    TotalProfit = c.CategoryBooks
                        .Sum(cb => cb.Book.Copies * cb.Book.Price)
                })
                .ToArray()
                .OrderByDescending(c => c.TotalProfit)
                .ThenBy(c => c.Name)
                .ToArray();



            foreach (var category in categories)
            {
                sb.AppendLine($"{category.Name} ${category.TotalProfit:f2}");
            }

            return sb.ToString().Trim();
        }

        //Problem 13
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var sb = new StringBuilder();

            var recent = context
                .Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    LatestBooks= c.CategoryBooks
                        .Select(cb => cb.Book)
                        .OrderByDescending(b => b.ReleaseDate)
                        .Select(b => new
                        {
                            BookTitle = b.Title,
                            ReleaseYear = b.ReleaseDate.Value.Year
                        })
                        .Take(3)
                        .ToArray()
                })
                .OrderBy(c => c.CategoryName)
                .ToArray();
           

            foreach (var category in recent)
            {

                sb.AppendLine($"--{category.CategoryName}");

                foreach (var book in category.LatestBooks)
                {

                    sb.AppendLine($"{book.BookTitle} ({book.ReleaseYear})");
                }
            }

            return sb.ToString().Trim();
        }

        //Problem 14
        public static void IncreasePrices(BookShopContext context)
        {
            foreach (var book in context.Books.Where(b => b.ReleaseDate.Value.Year < 2010))
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        //Problem 15
        public static int RemoveBooks(BookShopContext context)
        {
            var categoryBooksToRemove = context
                .BooksCategories
                .Where(bc => bc.Book.Copies < 4200)
                .ToArray();

            context.BooksCategories.RemoveRange(categoryBooksToRemove);

            context.SaveChanges();

            var booksToRemove = context
                .Books
                .Where(b => b.Copies < 4200)
                .ToList();

            context.Books.RemoveRange(booksToRemove);

         return context.SaveChanges();
        }
    }
}
