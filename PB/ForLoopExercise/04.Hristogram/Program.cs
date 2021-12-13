using System;

namespace _04.Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double p1 = 0.0;
            double p2 = 0.0;
            double p3 = 0.0;
            double p4 = 0.0;
            double p5 = 0.0;
            

            for (int i = 0; i < n; i++)
            {
                int num2 = int.Parse(Console.ReadLine());
                if(num2 < 200)
                {
                    p1++;
                }
                else if(num2 >= 200 && num2 < 400)
                {
                    p2++;
                }    
                else if(num2 >= 400 && num2 < 600)
                {
                    p3++;
                }
                else if(num2 >= 600 && num2 < 800)
                {
                    p4++;
                }    
                else if(num2 >= 800)
                {
                    p5++;
                }
            }
            Console.WriteLine($"{p1 / n * 100:f2}%");
            Console.WriteLine($"{p2 / n * 100:f2}%");
            Console.WriteLine($"{p3 / n * 100:f2}%");
            Console.WriteLine($"{p4 / n * 100:f2}%");
            Console.WriteLine($"{p5 / n * 100:f2}%");
        }
    }
}
