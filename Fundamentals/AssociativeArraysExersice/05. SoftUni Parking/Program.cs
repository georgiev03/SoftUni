using System;
using System.Collections.Generic;

namespace _05._SoftUni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> parking = new Dictionary<string, string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split();

                string command = line[0];
                string user = line[1];

                if (command == "register")
                {
                    string licensePlate = line[2];

                    if (parking.ContainsKey(user))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {parking[user]}");
                    }
                    else
                    {
                        parking.Add(user, licensePlate);
                        Console.WriteLine($"{user} registered {licensePlate} successfully");
                    }
                }
                else
                {
                    if (parking.Remove(user))
                    {
                        Console.WriteLine($"{user} unregistered successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {user} not found");
                    }
                }
            }

            foreach (var kvp in parking)
            {
                Console.WriteLine($"{kvp.Key} => {kvp.Value}");
            }
        }
    }
}
