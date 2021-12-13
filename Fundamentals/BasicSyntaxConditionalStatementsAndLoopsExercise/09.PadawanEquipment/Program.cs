using System;

namespace _09.PadawanEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double lightsaberPrice = double.Parse(Console.ReadLine());
            double robePrice = double.Parse(Console.ReadLine());
            double beltPrice = double.Parse(Console.ReadLine());

            double sumOfAll = lightsaberPrice * (Math.Ceiling( students * 1.1)) + robePrice * students + beltPrice * (students - (students / 6));
            budget -= sumOfAll;
            if (budget >= 0)
            {
                Console.WriteLine($"The money is enough - it would cost {sumOfAll:f2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {Math.Abs(budget):f2}lv more.");
            }
        }
    }
}
