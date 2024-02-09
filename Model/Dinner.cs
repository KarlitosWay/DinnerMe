using System.ComponentModel;

namespace DinnerMe.Model
{
    public class Dinner : Meal
    {
        // Every dinner can have one or more categories
        public enum Category { Fish, Vegetarian, Chicken, Beef, Pasta, Rice, Asian}

        // Unique identifier for the instance, required by the ORM (EntityFramework) / database
        public int dinnerId { get; set; }

        public Category category { get; set; }

        // Every dinner can have zero or more sides
        public List<Side> sides { get; set; } = new List<Side>();
    }

}
