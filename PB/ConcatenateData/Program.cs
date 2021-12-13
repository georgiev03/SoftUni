using System;

namespace ConcatenateData
{
    class Program
    {
        static void Main(string[] args)
        {
            double yards = double.Parse(Console.ReadLine());
            double price = yards * 7.61;
            double discount = price * 0.18;
            double final = price - price * 0.18;
            Console.WriteLine($"The final price is: {final:F2} lv.");
            Console.WriteLine($"The discount is: {discount:F2} lv.");

        }
    }
}
