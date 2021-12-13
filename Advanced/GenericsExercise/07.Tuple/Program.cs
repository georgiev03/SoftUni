using System;
using System.Linq;

namespace _07.Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] info = Console.ReadLine().Split();
            string fullName = info[0] + " " + info[1];
            string address = info[2];
            string town = info[3];

            if (info.Length > 3)
            {
                for (int i = 4; i < info.Length; i++)
                {
                    town += $" {info[i]}";
                }
            }

            info = Console.ReadLine().Split();
            string name = info[0];
            int liters = int.Parse(info[1]);
            bool isDrunk = info[2] == "drunk";

            info = Console.ReadLine().Split();
            string user = info[0];
            double balance = double.Parse(info[1]);
            string bank = info[2];

            Tuple<string, string, string> firstTuple = new Tuple<string, string,string>(fullName, address, town);
            Tuple<string, int,bool> secondTuple = new Tuple<string, int, bool>(name, liters, isDrunk);
            Tuple<string, double, string> thirdTuple = new Tuple<string, double,string>(user, balance, bank);

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);
        }
    }
}
