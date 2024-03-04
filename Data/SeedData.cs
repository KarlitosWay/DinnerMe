using DinnerMe.Model;


namespace DinnerMe.Data
{
    public class SeedData
    {
        public static void Initialize(DinnerMeContext db) {

            var fish_category = new Category() { name = "Fish" };
            var italian_category = new Category() { name = "Italian" };

            var dinners = new Dinner[] {
                new Dinner() {
                    name        = "Barramundi Foil Parcels",
                    description   = "Can steam forever",
                    imageUrl    = "img/default_meal.jpg",
                    method      = "1. Feck it all in a bit of tin foil\n2. Feckin' cook it, like.\n3. Sure that's it now Ted.",
                    notes       = "Yummy scrummy in my tummy.",
                    ingredients = new Ingredient[] {
                        new Ingredient() {  name = "Barra",
                                           imageUrl = "img/ingredients/default.jpg",
                                           quantity = 2 },
                        new Ingredient() {  name = "Courgette",
                                           imageUrl = "img/ingredients/default.jpg",
                                           quantity = 1 }
                    }.ToList<Ingredient>(),
                    categories = new Category[] {
                        fish_category,
                        italian_category
                    }.ToList<Category>()
                    // Note: No sides
                },
                new Dinner() {
                    name        = "Big Dirty Fry-up",
                    description   = "Greasy as",
                    imageUrl    = "img/default_meal.jpg",
                    method      = "1. Chuck it all on the bbq.\n2. Get stuck in.",
                    notes       = "Must check if this can be null...",
                    ingredients = new Ingredient[] {
                        new Ingredient() {  name = "Sausages",
                                           imageUrl = "img/ingredients/default.jpg",
                                           quantity = 10 },
                        new Ingredient() {  name = "Beans",
                                           imageUrl = "img/ingredients/default.jpg",
                                           quantity = 1 }
                    }.ToList<Ingredient>(),
                    categories = new Category[] { fish_category }.ToList<Category>()
                    // Note: No sides
                },
                new Dinner() {
                    name = "Trucha Patagonica",
                    description = "Salmon in rosti",
                    imageUrl = "img/default_meal.jpg",
                    method = "1. Make rosti\n2.Make rosti sandwich with salmon & rocket filling\n3.Servido!",
                    notes = "Can use spinach instead of rocket or even better use a spinach/rocket mix",
                    ingredients = new Ingredient[] {
                        new Ingredient() { name = "Salmon",
                                           imageUrl = "img/ingredients/default.jpg",
                                           quantity = 2 },
                        new Ingredient() { name = "Potatoes",
                                           imageUrl = "img/ingredients/default.jpg",
                                           quantity = 5 }
                    }.ToList<Ingredient>(),
                    categories = new Category[] { fish_category }.ToList<Category>(),
                    sides = new Side[] {
                        new Side() { name = "Stuffed Green Olives",
                                     imageUrl = "img/default_meal.jpg",
                                     method = "Just serve.",
                                     notes = "None",
                                     ingredients = new Ingredient[] {
                                         new Ingredient() { name = "Stuffed Green Olives",
                                                            imageUrl = "img/ingredients/default.jpg",
                                                            quantity = 1 }
                                     }.ToList<Ingredient>()
                                   },
                        new Side() { name = "Test Second Side",
                                     imageUrl = "img/default_meal.jpg",
                                     method = "Test Method.",
                                     notes = "None",
                                     ingredients = new Ingredient[] {
                                         new Ingredient() { name = "Test Ingredient for Test Side",
                                                            imageUrl = "img/ingredients/default.jpg",
                                                            quantity = 1 }
                                     }.ToList<Ingredient>()
                                   }
                    }.ToList<Side>()
                }
            };

            db.dinners.AddRange(dinners);
            db.SaveChanges();
        }
    }

}
