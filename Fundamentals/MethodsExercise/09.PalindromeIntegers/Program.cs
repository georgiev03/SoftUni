using System;
using System.Linq;
using Microsoft.VisualBasic;

namespace _09.PalindromeIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            string num = Console.ReadLine();
            while (num != "END")
            {
                CheckIfPalindrome(num);

                num = Console.ReadLine();
            }
        }

        private static void CheckIfPalindrome(string num)
        {
            bool isPalindrome = false;
            string reversedNum = ReverseNum(num);
            if (num == reversedNum)
            {
                isPalindrome = true;
            }

            Console.WriteLine(isPalindrome);
        }

        public static string ReverseNum(string num)
        {
            if (num == null) return null;

            // this was posted by petebob as well 
            char[] array = num.ToCharArray();
            Array.Reverse(array);
            return new String(array);
        }
    }
}
