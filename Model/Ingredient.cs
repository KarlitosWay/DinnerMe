namespace DinnerMe.Model
{
    public class Ingredient
    {
        public enum UnitOfMeasurement {
            Whole, // If we're using whole numbers, e.g. 3 x apples
            Millilitres,
            Litres,
            Grammes,
            Kilos,
            Can,
            Jar
        }

        // Unique identifier for the instance, required by the ORM (EntityFramework) / database
        public int Id { get; set; }

        public string name { get; set; }

        public UnitOfMeasurement measurement { get; set; }

        public string imageUrl { get; set; }

        // Every ingredient can be associated with zero or more dinners
        public List<Dinner> dinners { get; } = new List<Dinner>();

        // Every ingredient can be associated with zero or more sides
        public List<Side> sides { get; set; } = new List<Side>();

    }
}
