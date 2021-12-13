using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.OrderByAge
{
    class Person
    {
        public string Name { get; set; }

        public string ID { get; set; }

        public int Age { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "End")
                {
                    break;
                }

                string[] info = line.Split();

                string name = info[0];
                string id = info[1];
                int age = int.Parse(info[2]);

                Person person = new Person
                {
                    Name = name,
                    ID = id,
                    Age = age
                };

                people.Add(person);
            }

            List<Person> orderedPeople = people
                .OrderBy(a => a.Age)
                .ToList();

            foreach (var person in orderedPeople)
            {
                Console.WriteLine($"{person.Name} with ID: {person.ID} is {person.Age} years old.");
            }
        }
    }
}
