using System;

namespace _01.ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var username in usernames)
            {
                if (isValid(username))
                {
                    Console.WriteLine(username);
                }
            }
        }

        private static bool isValid(string username)
        {
            return IsValidLength(username) && ContainsValidChars(username);
        }

        private static bool ContainsValidChars(string username)
        {
            foreach (char symbol in username)
            {
                if (!char.IsLetterOrDigit(symbol) &&
                    symbol != '_' &&
                    symbol != '-')
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsValidLength(string username)
        {
            return username.Length >= 3 && username.Length <= 16;
        }
    }
}
