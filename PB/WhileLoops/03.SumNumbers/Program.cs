using System;

namespace _03.SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            
            int sum = 0;
            while (true)
            {
                if(sum >= firstNum)
                {
                    break;
                }
                int secondNum = int.Parse(Console.ReadLine());
                sum += secondNum;

            }
            Console.WriteLine(sum);
        }
    }
}
