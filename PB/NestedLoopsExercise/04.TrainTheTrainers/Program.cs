using System;

namespace _04.TrainTheTrainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int jury = int.Parse(Console.ReadLine());
            string presentation = Console.ReadLine();
            int count = 0;
            double allMarks = 0;

            while (presentation != "Finish")
            {
                double markSum = 0;
                for (int i = 0; i < jury; i++)
                {
                    count++;
                    double mark = double.Parse(Console.ReadLine());
                    markSum += mark;
                    allMarks += mark;

                }
                Console.WriteLine($"{presentation} - {markSum / jury:f2}.");
                presentation = Console.ReadLine();
            }
            Console.WriteLine($"Student's final assessment is {allMarks / count:f2}.");
        }
    }
}
