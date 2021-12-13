using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.GenericSwapMethodString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<double> elements = new List<double>();

            for (int i = 0; i < n; i++)
            {
                //string input = Console.ReadLine();
                double input = double.Parse(Console.ReadLine());
                elements.Add(input);
            }

            Box<double> box = new Box<double>(elements);

            double comparer = double.Parse(Console.ReadLine());


            Console.WriteLine(box.GreaterElements(elements, comparer));
        }
    }
}
