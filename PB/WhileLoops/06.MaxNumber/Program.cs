using System;

namespace _06.MaxNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int maxNum = int.MinValue;
            while (text != "Stop")
            {
                int num = int.Parse(text);
                if(num > maxNum)
                {
                    maxNum = num;
                }
                text = Console.ReadLine();
            }
            Console.WriteLine(maxNum);

        }
    }
}
