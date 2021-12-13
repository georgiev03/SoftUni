using System;

namespace _02.SummerOutfir
{
    class Program
    {
        static void Main(string[] args)
        {
            int degrees = int.Parse(Console.ReadLine());
            string time = Console.ReadLine();

            if (degrees >= 10 && degrees <= 18)
            {
                switch (time)
                {
                    case "Morning":
                        Console.WriteLine($"It's {degrees} degrees, get your Sweatshirt and Sneakers.");
                        break;
                    case "Afternoon":
                        Console.WriteLine($"It's {degrees} degrees, get your Shirt and Moccasins.");
                        break;
                    case "Evening":
                        Console.WriteLine($"It's {degrees} degrees, get your Shirt and Moccasins.");
                        break;
                }
            }
            else if (degrees > 18 && degrees <= 24)
            {
                switch (time)
                {
                    case "Morning":
                        Console.WriteLine($"It's {degrees} degrees, get your Shirt and Moccasins.");
                        break;
                    case "Afternoon":
                        Console.WriteLine($"It's {degrees} degrees, get your T-Shirt and Sandals.");
                        break;
                    case "Evening":
                        Console.WriteLine($"It's {degrees} degrees, get your Shirt and Moccasins.");
                        break;
                }
            }
            else if(degrees >= 25)
            {
                switch (time)
                {
                    case "Morning":
                        Console.WriteLine($"It's {degrees} degrees, get your T-Shirt and Sandals.");
                        break;
                    case "Afternoon":
                        Console.WriteLine($"It's {degrees} degrees, get your Swim Suit and Barefoot.");
                        break;
                    case "Evening":
                        Console.WriteLine($"It's {degrees} degrees, get your Shirt and Moccasins.");
                        break;
                }
            }
        }
        
    }
}
