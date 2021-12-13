using System;

namespace _02.ExamPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int unsatisfied = int.Parse(Console.ReadLine());
            string problem = Console.ReadLine();
            

            int unsatisfiedCount = 0;
            int problemsCount = 0;
            double gradeSum = 0;
            string lastProblem = "";
            

            while (problem != "Enough")
            {
               int grade = int.Parse(Console.ReadLine());
                lastProblem = problem;
                gradeSum += grade;
                problemsCount++;
                if(grade <= 4)
                {
                    unsatisfiedCount++;
                }
                if(unsatisfiedCount == unsatisfied)
                {
                    Console.WriteLine($"You need a break, {unsatisfied} poor grades.");
                    break;
                }
                problem = Console.ReadLine();

            }
            if(problem == "Enough")
            {
                Console.WriteLine($"Average score: {gradeSum / problemsCount:f2}");
                Console.WriteLine($"Number of problems: {problemsCount}");
                Console.WriteLine($"Last problem: {lastProblem}");
            }
        }
    }
}
