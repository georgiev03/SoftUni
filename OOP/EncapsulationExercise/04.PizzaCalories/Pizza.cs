using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name)
        {
            Name = name;
            Toppings = new List<Topping>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (value.Length > 15 || value.Length < 1)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                name = value;
            }
        }

        public Dough Dough
        {
            set => dough = value;
        }

        public List<Topping> Toppings { get; set; }


        public void AddTopping(Topping topping)
        {
            if (Toppings.Count == 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }

            Toppings.Add(topping);
        }

        private double CalcCalories()
        {
            double calories = dough.CalcCalories;
            foreach (var topping in Toppings)
            {
                calories += topping.CalcCalories;
            }

            return calories;
        }

        public override string ToString()
        {
            return $"{Name} - {CalcCalories():f2} Calories.";
        }
    }
}
