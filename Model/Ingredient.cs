namespace DinnerMe.Model
{
    public class Ingredient
    {
        // TODO, can I make these attributes private and have a constructor with default parameters (e.g. quantity = 1)
        // or will this break EntityFramework? (applies to all classes in /Model/)
        // Also note; I've disabled <Nullable> in the csproj file to stop irritating warnings.
        // Really I'd like to make these attributes private/internal and use a ctor to enforce initialisation, but not
        // sure if you can do this with EF? TODO.

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
