using System;

namespace _07.MinNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int minNum = int.MaxValue;

            while (text != "Stop")
            {
                int num = int.Parse(text);
                if(num < minNum)
                {
                    minNum = num;
                }
                text = Console.ReadLine();
            }
            Console.WriteLine(minNum);
        }
    }
}
