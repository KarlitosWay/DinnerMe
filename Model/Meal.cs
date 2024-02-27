namespace DinnerMe.Model
{
    abstract public class Meal
    {
        public string name { get; set; }

        // Not quite a description, used a short meal mneumonic
        public string mneumonic { get; set; }

        // Path to image representing the meal
        public string imageUrl { get; set; }

        // Stores the method used by the recipe
        public string method { get; set; }

        // Annotated notes on the method (not sure how to implement this yet)
        public string notes { get; set; }

        // A meal can have one or more ingredients
        public List<Ingredient> ingredients { get; set; } = new List<Ingredient>();

    }
}
