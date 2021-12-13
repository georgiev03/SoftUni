using System;

namespace _04.PasswordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string pass = Console.ReadLine();
            bool isValid = true;
            if (!FirstCheck(pass))
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
                isValid = false;
            }

            if (!SecondCheck(pass))
            {
                Console.WriteLine("Password must consist only of letters and digits");
                isValid = false;
            }

            if (!ThirdCheck(pass))
            {
                Console.WriteLine("Password must have at least 2 digits");
                isValid = false;
            }

            if (isValid)
            {
                Console.WriteLine("Password is valid");
            }
        }
        private static bool FirstCheck(string pass)
        {
            bool isValid = true;
            int count = pass.Length;

            if (count < 6 || count > 10)
            {
                isValid = false;
            }

            return isValid;
        }

        private static bool SecondCheck(string pass)
        {
            bool isValid = true;

            foreach (char letter in pass)
            {
                if (!(char.IsLetterOrDigit(letter)))
                {
                    isValid = false;
                }
            }

            return isValid;
        }
        private static bool ThirdCheck(string pass)
        {
            bool isValid = true;
            int count = 0;
            foreach (char character in pass)
            {
                if (char.IsDigit(character))
                {
                    count++;
                }
            }

            if (!(count >= 2))
            {
                isValid = false;
            }

            return isValid;
        }
    }
}
