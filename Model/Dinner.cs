
namespace DinnerMe.Model
{
    public class Dinner : Meal
    {
        // Every dinner can have one or more categories
        public List<Category> categories { get; set; } = new List<Category>();

        // Every dinner can have zero or more sides
        public List<Side> sides { get; set; } = new List<Side>();
    }

}
