using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace DinnerMe.Model
{
    abstract public class Meal
    {

        // Unique identifier for the instance, required by the ORM (EntityFramework) / database
        public int Id { get; set; }

        [Required,
            MinLength(3, ErrorMessage = "Please use a Name bigger than 3 letters."),
            MaxLength(30, ErrorMessage = "Please use a Name less than 30 letters.")]
        public string name { get; set; }

        // Short meal description
        public string description { get; set; }

        // Path to image representing the meal
        public string imageUrl { get; set; }

        // Stores the method used by the recipe
        [Required, MaxLength(5000, ErrorMessage = "Method should be less than 5000 letters.")]
        public string method { get; set; }

        // Annotated notes on the method (not sure how to implement this yet)
        public string notes { get; set; }

        // A meal can have one or more ingredients
        public List<MealIngredient> ingredients { get; set; } = new();

    }
}
