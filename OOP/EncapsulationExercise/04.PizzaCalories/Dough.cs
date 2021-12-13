using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private int weight;
        private string bakingTechnique;

        private Dictionary<string, double> calories = new Dictionary<string, double>
        {
            {"white", 1.5},
            {"wholegrain", 1},
            {"crispy", 0.9},
            {"chewy", 1.1},
            {"homemade", 1}
        };

        public Dough(string flourType, string bakingTechnique, int weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }
        public string FlourType
        {
            get => flourType;
            private set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                flourType = value.ToLower();
            }
        }

        public string BakingTechnique
        {
            get => bakingTechnique;
            private set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                bakingTechnique = value.ToLower();
            }
        }

        public int Weight
        {
            get => weight;
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                weight = value;
            }
        }

        public double CalcCalories => (2 * Weight) * calories[BakingTechnique] * calories[FlourType];
    }
}
