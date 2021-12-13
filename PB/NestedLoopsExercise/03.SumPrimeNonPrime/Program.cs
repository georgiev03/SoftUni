using System;

namespace _03.SumPrimeNonPrime
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int primeNums = 0;
            int nonPrimeNums = 0;
            while (input != "stop")
            {
                int num = int.Parse(input);
                if (num < 0)
                {
                    Console.WriteLine("Number is negative.");
                }
                else if (num <= 1)
                {
                    nonPrimeNums+= num;
                }
                else if (num == 2)
                {
                    primeNums += num;
                }
                else if (num % 2 == 0)
                {
                    nonPrimeNums += num;
                }
                else
                {
                    int boundary = (int)Math.Floor(Math.Sqrt(num));
                    bool isPrime = true;

                    for (int i = 3; i <= boundary; i += 2)
                    {
                        if (num % i == 0)
                        {
                            isPrime = false;
                            break;
                        }
                        
                    }
                    if(isPrime)
                    {
                        primeNums += num;
                    }
                    else
                    {
                        nonPrimeNums += num;
                    }
                }
                input = Console.ReadLine();

            }
            Console.WriteLine($"Sum of all prime numbers is: {primeNums}");
            Console.WriteLine($"Sum of all non prime numbers is: {nonPrimeNums}");
        }
    }
}
