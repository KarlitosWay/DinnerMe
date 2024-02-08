using System.ComponentModel;

namespace DinnerMe.Model
{
    public class Dinner : Meal
    {
        // Every dinner can have one or more categories
        public enum Category { Fish, Vegetarian, Chicken, Beef, Pasta, Rice, Asian}

        public Category category { get; set; }

        // Every dinner can have zero or more sides
        public List<Side> sides { get; set; }
    }

}
