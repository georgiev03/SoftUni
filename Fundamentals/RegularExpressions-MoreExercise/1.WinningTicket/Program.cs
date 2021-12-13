using System;
using System.Text.RegularExpressions;

namespace _1.WinningTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex validator = new Regex(@".{20}");

            Regex winner = new Regex(@"[#@\$\^]{6,10}");


            string[] tickets = Console.ReadLine()
                .Split(new char[] {',', '\t', ' '},StringSplitOptions.RemoveEmptyEntries);

            foreach (var ticket in tickets)
            {
                Match match = validator.Match(ticket);

                if (!match.Success)
                {
                    Console.WriteLine("invalid ticket");
                    continue;
                }

                string first = ticket.Substring(0, 10);
                string second = ticket.Substring(10);

                Match checkFirst = winner.Match(first);
                Match checkSecond = winner.Match(second);

                if (!(checkFirst.Success ||
                    checkSecond.Success))
                {
                    Console.WriteLine($"ticket \"{ticket}\" - no match");
                }
                else if (checkFirst.Length == 10 &&
                    checkSecond.Length == 10 &&
                    checkFirst.Value == checkSecond.Value)
                {
                    Console.WriteLine($"ticket \"{ticket}\" - 10{checkSecond.Value[1]} Jackpot!");
                }
                else if(checkFirst.Value == checkSecond.Value)
                {
                    Console.WriteLine($"ticket \"{ticket}\" - {checkSecond.Length}{checkSecond.Value[1]}");
                }
                
            }
        }
    }
}
