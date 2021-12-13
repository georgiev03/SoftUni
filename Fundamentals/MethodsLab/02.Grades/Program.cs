using System;

namespace _02.Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            double grade = double.Parse(Console.ReadLine());
            string result = Grade(grade);
            Console.WriteLine(result);
        }

        static string Grade(double grade)
        {
            string gradeInWords = "";
            if (grade >= 5.5)
            {
                gradeInWords = "Excellent";
            }
            else if (grade >= 4.5)
            {
                gradeInWords = "Very good";
            }
             else if (grade >= 3.5)
            {
                gradeInWords = "Good";
            }
            else if (grade >= 3)
            {
                gradeInWords = "Poor";
            }
            else
            {
                gradeInWords = "Fail";
            }

            return gradeInWords;
        }
    }
}
