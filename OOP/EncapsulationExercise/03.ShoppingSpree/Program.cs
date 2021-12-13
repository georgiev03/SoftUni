using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            List<Product> products = new List<Product>();

            try
            {
                persons = Console.ReadLine().Split(';' , StringSplitOptions.RemoveEmptyEntries).ToList()
                    .Select(t => t.Split('='))
                    .Select(p => new Person(p[0], decimal.Parse(p[1])))
                    .ToList(); ;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            try
            {
                products = Console.ReadLine().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToList()
                    .Select(t => t.Split('='))
                    .Select(p => new Product(p[0], decimal.Parse(p[1])))
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            while (true)
            {
                string[] input = Console.ReadLine().Split();

                if (input[0] == "END")
                {
                    break;
                }

                string name = input[0];
                string product = input[1];

                Person currPerson = persons.First(p => p.Name == name);
                Product currProduct = products.First(p => p.Name == product);

                Console.WriteLine(currPerson.AddProduct(currProduct));
            }

            foreach (var person in persons)
            {
                Console.WriteLine(person);
            }
        }
    }
}
