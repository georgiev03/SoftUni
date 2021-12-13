using System;

namespace _04.PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            string pizzaName = Console.ReadLine().Split()[1];
            try
            {
                Pizza pizzaTry = new Pizza(pizzaName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            Pizza pizza = new Pizza(pizzaName);

            string[] doughInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            try
            {
                pizza.Dough = new Dough(doughInput[1], doughInput[2], int.Parse(doughInput[3]));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            while (true)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "END")
                {
                    break;
                }

                string type = input[1];
                int weight = int.Parse(input[2]);

                try
                {
                    Topping topping = new Topping(type, weight);
                    pizza.AddTopping(topping);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }

            Console.WriteLine(pizza);
        }
    }
}
