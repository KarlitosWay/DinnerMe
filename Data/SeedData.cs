using DinnerMe.Model;


namespace DinnerMe.Data
{
    public class SeedData
    {
        public static void Initialize(DinnerMeContext db) {

            var dinners = new Dinner[] {
                new Dinner() {
                    dinnerId = 1,
                    name        = "Barramundi Foil Parcels",
                    imageUrl    = "img/dinners/default.jpg",
                    method      = "1. Feck it all in a bit of tin foil\n2. Feckin' cook it, like.\n3. Sure that's it now Ted.",
                    notes       = "Yummy scrummy in my tummy.",
                    ingredients = new Ingredient[] {
                        new Ingredient() { name = "Barra",
                                           imageUrl = "img/ingredients/default.jpg",
                                           quantity = 2 },
                        new Ingredient() { name = "Courgette",
                                           imageUrl = "img/ingredients/default.jpg" }
                    }.ToList<Ingredient>(),
                    category = Dinner.Category.Fish,
                    // Note: No sides
                },
                new Dinner() {
                    dinnerId = 2,
                    name = "Trucha Patagonica",
                    imageUrl = "img/dinners/default.jpg",
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
                    category = Dinner.Category.Fish,
                    sides = new Side[] {
                        new Side() { sideId = 1,
                                     name = "Stuffed Green Olives",
                                     imageUrl = "img/sides/default.jpg",
                                     method = "Just serve.",
                                     notes = "None",
                                     ingredients = new Ingredient[] {
                                         new Ingredient() { name = "Stuffed Green Olives",
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
