using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        public string Name { get; set; }

        public int Capacity { get; set; }

        public int MaxAlcoholLevel { get; set; }

        public List<Ingredient> Ingredients { get; set; }

        public int CurrentAlcoholLevel => Ingredients.Sum(alc => alc.Alcohol);


        public Cocktail(string name, int maxAlcoholLevel, int capacity)
        {
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
            Ingredients = new List<Ingredient>();
        }

        public void Add(Ingredient ingredient)
        {
            if (!Ingredients.Contains(ingredient)
                && CurrentAlcoholLevel <= MaxAlcoholLevel
                                                  && Ingredients.Count < Capacity)
            {
                Ingredients.Add(ingredient);
            }
        }

        public bool Remove(string name)
        {
            Ingredient ingredient = Ingredients.Find(n => n.Name == name);

            if (ingredient != null)
            {
                Ingredients.Remove(ingredient);
                return true;
            }

            return false;
        }

        public Ingredient FindIngredient(string name)
        {
            Ingredient ingredient = Ingredients.Find(n => n.Name == name);

            return ingredient;
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            int max = 0;

            foreach (var ingredient in Ingredients)
            {
                if (ingredient.Alcohol > max)
                {
                    max = ingredient.Alcohol;
                }
            }

            return Ingredients.OrderByDescending(a => a.Alcohol).FirstOrDefault();
        }

        public string Report()
        {
            var result = $"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}\r\n";

            foreach (var ingredient in Ingredients)
            {
                result += (ingredient.ToString());
            }
            return result.TrimEnd();
        }

    }
}
