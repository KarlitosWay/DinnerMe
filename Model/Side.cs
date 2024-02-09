
namespace DinnerMe.Model
{
    // Describes a side that can be used as an accompaniment to a dinner, e.g. garlic bread, salad...
    public class Side : Meal
    {
        // Unique identifier for the instance, required by the ORM (EntityFramework) / database
        public int sideId { get; set; }
    }

}
