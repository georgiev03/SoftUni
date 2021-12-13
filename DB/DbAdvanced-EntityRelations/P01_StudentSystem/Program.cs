using System;
using P01_StudentSystem.Data;

namespace P01_StudentSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbContext = new StudentSystemContext();

            if (dbContext.Database.EnsureCreated())
            {
                Console.WriteLine("Evala");
            }
        }
    }
}
