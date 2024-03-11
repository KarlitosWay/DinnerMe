using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using DinnerMe.Data;
using DinnerMe.Model;


namespace DinnerMe.Controllers
{

    // This class creates a controller that allows us to query the database for dinners and
    // returns them as JSON at the (https://<host>:<port>/dinners) URL.
    [Route("dinners")]
    [ApiController]
    public class DinnerMeController : Controller
    {
        private readonly DinnerMeContext dinnerMeContext;

        public DinnerMeController(DinnerMeContext db)
        {
            dinnerMeContext = db;
        }

        [HttpGet("getdinners")]
        public async Task<ActionResult<List<Dinner>>> GetDinners()
        {
            // Just Dinners
            return (await dinnerMeContext.dinners.ToListAsync()).OrderByDescending(d => d.name).ToList();

            // Dinners joined with sides
            //return (await _db.dinners.Include(d => d.sides).ToListAsync()).OrderByDescending(d => d.name).ToList();

            // Dinners joined with ingredients
            //return (await _db.dinners.Include(d => d.ingredients).ToListAsync()).OrderByDescending(d => d.name).ToList();

            // Nice big join between dinners, sides and ingredients
            //return (await _db.dinners.Include(d => d.sides).Include(d => d.ingredients).ToListAsync()).OrderByDescending(d => d.name).ToList();
        }

        [HttpPost("adddinner")]
        public async Task<ActionResult<int>> AddDinner(Dinner dinner)
        {
            dinnerMeContext.dinners.Attach(dinner);
            await dinnerMeContext.SaveChangesAsync();

            return dinner.Id;
        }

        [HttpGet("getcategories")]
        public async Task<ActionResult<List<Category>>> GetCategories()
        {
            return (await dinnerMeContext.categories.ToListAsync()).OrderByDescending(c => c.name).ToList();
        }

        [HttpPost("addcategory")]
        public async Task<ActionResult<int>> AddCategory(Category category)
        {
            dinnerMeContext.categories.Attach(category);
            await dinnerMeContext.SaveChangesAsync();

            return category.Id;
        }

        [HttpGet("getingredients")]
        public async Task<ActionResult<List<Ingredient>>> GetIngredients()
        {
            return (await dinnerMeContext.ingredients.ToListAsync()).OrderByDescending(c => c.name).ToList();
        }

        [HttpPost("addingredient")]
        public async Task<ActionResult<int>> AddIngredient(Ingredient ingredient)
        {
            dinnerMeContext.ingredients.Attach(ingredient);
            await dinnerMeContext.SaveChangesAsync();

            return ingredient.Id;
        }

    }

}
