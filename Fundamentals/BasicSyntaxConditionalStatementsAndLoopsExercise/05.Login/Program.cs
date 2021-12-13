using System;

namespace _05.Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = null;
            bool isBlocked = false;
            int attempts = 0;

            for (int i = username.Length - 1; i >= 0; i--)
            {
                password += username[i];
            }

            while (!isBlocked)
            {
                string inputPass = Console.ReadLine();
                if(inputPass == password)
                {
                    break;
                }
                attempts++;
                if(attempts == 4)
                {
                    isBlocked = true;
                    break;
                }
                Console.WriteLine("Incorrect password. Try again.");
            }
            if (isBlocked)
            {
                Console.WriteLine($"User {username} blocked!");
            }
            else
            {
                Console.WriteLine($"User {username} logged in.");
            }
        }
    }
}
