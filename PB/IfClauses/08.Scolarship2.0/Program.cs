using System;

namespace _08.Scolarship2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            double income = double.Parse(Console.ReadLine());
            double grades = double.Parse(Console.ReadLine());
            double MinWorkingSalary = double.Parse(Console.ReadLine());   //tazi bachka

            double socialScholarship = Math.Floor(MinWorkingSalary * 0.35);
            double excellentScolarship = Math.Floor(grades * 25);
            //bez pravo na stipendiq
            //samo socialna stipendiq
            // samo otlichna stipendiq
            //socialna ili otlichna v zavisimost koe dava poveche
            if(grades >= 5.50)
            {
                if(excellentScolarship >= socialScholarship || income > MinWorkingSalary )
                {
                    Console.WriteLine($"You get a scholarship for excellent results {excellentScolarship} BGN");
                }
                else
                {
                    Console.WriteLine($"You get a Social scholarship {socialScholarship} BGN");
                }
            }
            else if (income < MinWorkingSalary && grades > 4.50)
            {
                Console.WriteLine($"You get a Social scholarship {socialScholarship} BGN");

            }
            else
            {
                Console.WriteLine("You cannot get a scholarship!");
            }
        }
        
    }
}
