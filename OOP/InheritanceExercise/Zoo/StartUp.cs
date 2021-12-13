using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic;

namespace Zoo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Snake snake = new Snake("Vlado");

            
            (string name, int a, decimal kk) = snake;
            Console.WriteLine(a);

            var names = new[] {"Zlati", "Kosio", "Stefan"};
            var ages = new[] {16, 22, 5};

            var zipped = names.Zip(ages);
            Console.WriteLine(string.Join(" ",zipped));

            if (snake is not  Snake {Name: "Joshkun"})
            {
                Console.WriteLine("koko");
            }
        }
    }
}