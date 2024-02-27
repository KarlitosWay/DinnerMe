
namespace DinnerMe.Model
{
    public class Dinner : Meal
    {
        // Unique identifier for the instance, required by the ORM (EntityFramework) / database
        public int Id { get; set; }

        // Every dinner can have one or more categories
        public List<Category> categories { get; set; } = new List<Category>();

        // Every dinner can have zero or more sides
        public List<Side> sides { get; set; } = new List<Side>();
    }

}
