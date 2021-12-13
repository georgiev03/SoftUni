namespace CocktailParty
{
    public class Ingredient
    {
        public string Name { get; set; }

        public int Alcohol { get; set; }

        public int Quantity { get; set; }

        public Ingredient(string name, int alcohol, int quantity)
        {
            Name = name;
            Alcohol = alcohol;
            Quantity = quantity;
        }

        public override string ToString()
        {
            string result = $"Ingredient: {Name}\r\n" +
                            $"Quantity: {Quantity}\r\n" +
                            $"Alcohol: {Alcohol}";

            return result;
        }
    }
}
