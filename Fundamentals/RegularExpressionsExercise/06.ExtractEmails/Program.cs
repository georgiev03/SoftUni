using System;
using System.Text.RegularExpressions;

namespace _06.ExtractEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Regex emailRegex = new Regex(@"(^|(?<=\s))[\da-zA-Z]+([-._][a-zA-Z\d]+)*@[a-zA-Z]+(-[a-zA-Z]+)*(\.[a-zA-Z]+)+");

            var matchedEmails = emailRegex.Matches(text);

            foreach (Match matchedEmail in matchedEmails)
            {
                Console.WriteLine(matchedEmail.Value);
            }
        }
    }
}
