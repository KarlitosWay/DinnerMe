
namespace DinnerMe.Model
{
    public class Dinner : Meal
    {
        // Every dinner can have zero or more sides
        public List<Side> sides { get; set; } = new List<Side>();
    }

}
