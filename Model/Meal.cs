namespace DinnerMe.Model
{
    abstract public class Meal
    {
        public string name { get; set; }

        public string imageUrl { get; set; }

        // Stores the method used by the recipe
        public string method { get; set; }

        // Annotated notes on the method (not sure how to implement this yet)
        public string notes { get; set; }

        public List<Ingredient> ingredients = new List<Ingredient>();

    }
}
