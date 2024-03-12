namespace DinnerMe.Model
{
    // This class is required because EF doesn't know how to handle the following relationship in Meal:
    // List<KeyValuePair<Ingredient, string>> ingredients
    // So instead, we represent the relationship using this separate class and have a list
    // of MealIngredients in Meal
    public class MealIngredient
    {
        public int Id { get; set; } // Primary key
        public Meal meal { get; set; }
        public Ingredient ingredient { get; set; }
        public decimal quantity { get; set; }
    }

}
