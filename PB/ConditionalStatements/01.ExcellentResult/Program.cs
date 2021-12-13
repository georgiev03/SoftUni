using System;

namespace _01.ExcellentResult
{
    class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();
            if (figure == "square")
            {
                double length = double.Parse(Console.ReadLine());
                Console.WriteLine($"{length * length:F3}");
            }
            else if (figure == "rectangle")
            {
                double length = double.Parse(Console.ReadLine());
                double heigth = double.Parse(Console.ReadLine());
                Console.WriteLine(($"{length * heigth:F3}"));
            }
            else if (figure == "circle")
            {
                double radius = double.Parse(Console.ReadLine());
                Console.WriteLine($"{Math.PI * radius*radius:F3}");
            }
            else if (figure == "triangle")
            {
                double length = double.Parse(Console.ReadLine());
                double heigth = double.Parse(Console.ReadLine());
                Console.WriteLine(($"{(length * heigth)/2:F3}"));
            }
        }
    }
}
