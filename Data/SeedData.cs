using DinnerMe.Model;


namespace DinnerMe.Data
{
    public class SeedData
    {
        public static void Initialize(DinnerMeContext db) {

            var fish_category = new Category() { name = "Fish" };
            var italian_category = new Category() { name = "Italian" };

            var barra_ingredient = new Ingredient() { name = "Barra", measurement = Ingredient.UnitOfMeasurement.Whole };
            var courgette_ingredient = new Ingredient() { name = "Courgette", measurement = Ingredient.UnitOfMeasurement.Whole };
            var sausage_ingredient = new Ingredient() { name = "Sausages", measurement = Ingredient.UnitOfMeasurement.Whole };
            var beans_ingredient = new Ingredient() { name = "Beans", measurement = Ingredient.UnitOfMeasurement.Whole };
            var salmon_ingredient = new Ingredient() { name = "Salmon", measurement = Ingredient.UnitOfMeasurement.Whole };
            var potatoes_ingredient = new Ingredient() { name = "Potatoes", measurement = Ingredient.UnitOfMeasurement.Whole };
            var sfd_green_olives_ingredient = new Ingredient() {
                name = "Stuffed Green Olives", measurement = Ingredient.UnitOfMeasurement.Whole };
            var test_ingredient = new Ingredient() { name = "Test Ingredient", measurement = Ingredient.UnitOfMeasurement.Grammes };


            var dinners = new Dinner[] {
                new Dinner() {
                    name        = "Barramundi Foil Parcels",
                    description   = "Can steam forever",
                    imageUrl    = "img/default_meal.jpg",
                    method      = "1. Feck it all in a bit of tin foil\n2. Feckin' cook it, like.\n3. Sure that's it now Ted.",
                    notes       = "Yummy scrummy in my tummy.",
                    ingredients = new List<MealIngredient> {
                        new MealIngredient{ ingredient = barra_ingredient, quantity = "2" } ,
                        new MealIngredient{ ingredient = courgette_ingredient, quantity = "3" }
                    },
                    categories = new Category[] {
                        fish_category,
                        italian_category
                    }.ToList<Category>()
                    // Note: No sides
                },
                new Dinner() {
                    name        = "Big Dirty Fry-up",
                    description = "Greasy as",
                    imageUrl    = "img/default_meal.jpg",
                    method      = "1. Chuck it all on the bbq.\n2. Get stuck in.",
                    notes       = "Must check if this can be null...",
                    ingredients = new List<MealIngredient> {
                        new MealIngredient{ ingredient = sausage_ingredient, quantity = "10" } ,
                        new MealIngredient{ ingredient = beans_ingredient, quantity = "1" }
                    },
                    categories = new Category[] { fish_category }.ToList<Category>()
                    // Note: No sides
                },
                new Dinner() {
                    name = "Trucha Patagonica",
                    description = "Salmon in rosti",
                    imageUrl = "img/default_meal.jpg",
                    method = "1. Make rosti\n2.Make rosti sandwich with salmon & rocket filling\n3.Servido!",
                    notes = "Can use spinach instead of rocket or even better use a spinach/rocket mix",
                    ingredients = new List<MealIngredient> {
                        new MealIngredient{ ingredient = salmon_ingredient, quantity = "2" } ,
                        new MealIngredient{ ingredient = potatoes_ingredient, quantity = "4" }
                    },
                    categories = new Category[] { fish_category }.ToList<Category>(),
                    sides = new Side[] {
                        new Side() { name = "Stuffed Green Olives",
                                     imageUrl = "img/default_meal.jpg",
                                     method = "Just serve.",
                                     notes = "None",
                                     ingredients = new List<MealIngredient> {
                                         new MealIngredient{ ingredient = sfd_green_olives_ingredient, quantity = "1" }
                                     },
                                   },
                        new Side() { name = "Test Second Side",
                                     imageUrl = "img/default_meal.jpg",
                                     method = "Test Method.",
                                     notes = "None",
                                     ingredients = new List<MealIngredient> {
                                         new MealIngredient{ ingredient = test_ingredient, quantity = "100g" }
                                     },
                                   }
                    }.ToList<Side>()
                }
            };

            db.dinners.AddRange(dinners);
            db.SaveChanges();
        }
    }

}
