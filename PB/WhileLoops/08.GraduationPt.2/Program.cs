using System;

namespace _08.GraduationPt._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double gradeSum = 0;
            int year = 1;
            int povtarqniq = 0;
            while (true)
            {
                double grade = double.Parse(Console.ReadLine());
                if(grade >= 4)
                {
                    gradeSum += grade;
                    year++;
                }
                else
                {
                    povtarqniq++;
                }
                if(povtarqniq == 2)
                {
                    Console.WriteLine($"{name} has been excluded at {year} grade");
                    break;
                }
                if(year == 13)
                {
                    Console.WriteLine($"{name} graduated. Average grade: {gradeSum / 12:f2}");
                    break;
                }
            }

        }
    }
}
