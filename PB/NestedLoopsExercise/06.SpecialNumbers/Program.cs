using System;

namespace _06.SpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 1111; i < 9999; i++)
            {
                bool isSpecial = true;
                for (int index = 0; index < 4; index++)
                {
                    int num = int.Parse(i.ToString()[index].ToString());
                    if(num == 0)
                    {
                        isSpecial = false;
                        break;
                    }
                    else if (n % num != 0)
                    {
                        isSpecial = false;
                    }

                }

                if (isSpecial)
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}
