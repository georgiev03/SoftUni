using System;
using Demo.Models;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new ApplicationDbContext();
            Console.WriteLine(db.Database.EnsureCreated());
        }
    }
}
