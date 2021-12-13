using System;

namespace akvarium
{
    class Program
    {
        static void Main(string[] args)
        {
            int L = int.Parse(Console.ReadLine());
            int W = int.Parse(Console.ReadLine()); 
            int H = int.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine());

            double V = L * W * H;
            double liters = V * 0.001;
            double percentage = percent * 0.01;
            double all = liters * (1 - percentage);

            Console.WriteLine(all);

        }
    }
}
