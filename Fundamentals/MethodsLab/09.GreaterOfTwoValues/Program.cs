using System;

namespace _09.GreaterOfTwoValues
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            string first = Console.ReadLine();
            string second = Console.ReadLine();

            Console.WriteLine(GetMax(type, first, second));
        }

        static string GetMax(string type, string first, string second)
        {
            string result = "";
            switch (type)
            {
                case "int":
                    result = Convert.ToString(Math.Max(int.Parse(first), int.Parse(second)));
                    break;
                case "char":
                    result = Convert.ToString(Convert.ToChar(Math.Max(char.Parse(first), char.Parse(second))));
                    break;
                default:
                    result = 
                    break;
            }

            return result;
        }
    }
}
