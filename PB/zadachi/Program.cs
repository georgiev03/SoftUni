using System;

namespace zadachi
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int cooks = int.Parse(Console.ReadLine());
            int cakes = int.Parse(Console.ReadLine());
            int waffles = int.Parse(Console.ReadLine());
            int pancakes = int.Parse(Console.ReadLine());

            double cakesPrice = cakes * 45;
            double wafflesPrice = waffles * 5.80;
            double pancakesPrice = pancakes * 3.20;
            double sumForday = (cakesPrice + wafflesPrice + pancakesPrice) * cooks;
            double oborot = sumForday * days;
            double result = oborot - (oborot * 0.125);

            Console.WriteLine(result);
            


        }
    }
}
