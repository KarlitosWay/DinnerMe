namespace DinnerMe.Model
{
    public class Category
    {

        // Unique identifier for the instance, required by the ORM (EntityFramework) / database
        public int Id { get; set; }

        public string name { get; set; }

        public bool selected { get; set; } = false;


        // Every category can be associated with zero or more dinners
        public List<Dinner> dinners { get; } = new List<Dinner>();

    }
}
