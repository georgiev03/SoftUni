using System;

namespace BasicSyntaxConditionalStatementsAndLoopsExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            if(age >= 66)
            {
                Console.WriteLine("elder");
            }
            else if(age > 19)
            {
                Console.WriteLine("adult");
            }
            else if (age > 13)
            {
                Console.WriteLine("teenager");
            }
            else if (age > 2)
            {
                Console.WriteLine("child");
            }
            else
            {
                Console.WriteLine("baby");
            }
        }
    }
}
