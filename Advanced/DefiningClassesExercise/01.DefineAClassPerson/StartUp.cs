using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var family = new Family();

            for (int i = 0; i < n; i++)
            {
                var cmdArgs = Console.ReadLine().Split();
                string name = cmdArgs[0];
                int age = int.Parse(cmdArgs[1]);

                var person = new Person(name, age);
                family.AddMember(person);
            }

            HashSet<Person> pplAbove30 = family.GetAllPplAbove30();

            Console.WriteLine(string.Join("\n", pplAbove30));
        }
    }
}
