namespace DinnerMe.Model
{
    public class Ingredient
    {

        // Unique identifier for the instance, required by the ORM (EntityFramework) / database
        public int Id { get; set; }

        public string name { get; set; }

        public string imageUrl { get; set; }

        // TODO, need to support different quantity types, e.g. 3 x tomatoes, 100g butter, 1 litre milk...
        public int quantity { get; set; }

        // Every ingredient can be associated with zero or more dinners
        public List<Dinner> dinners { get; } = new List<Dinner>();

        // Every ingredient can be associated with zero or more sides
        public List<Side> sides { get; set; } = new List<Side>();

    }
}
