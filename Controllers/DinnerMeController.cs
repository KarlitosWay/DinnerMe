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
        private readonly DinnerMeContext _db;

        public DinnerMeController(DinnerMeContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<List<Dinner>>> GetDinners()
        {
            // Just Dinners
            //return (await _db.dinners.ToListAsync()).OrderByDescending(d => d.name).ToList();

            // Dinners joined with sides, works ok
            /*
             SELECT "d"."Id", "d"."category", "d"."imageUrl", "d"."method", "d"."name", "d"."notes", "s"."Id", "s"."DinnerId", "s"."imageUrl", "s"."method", "s"."name", "s"."notes"
            FROM "dinners" AS "d"
            LEFT JOIN "sides" AS "s" ON "d"."Id" = "s"."DinnerId"
            ORDER BY "d"."Id"
            */
            //return (await _db.dinners.Include(d => d.sides).ToListAsync()).OrderByDescending(d => d.name).ToList();

            // Dinners joined with ingredients, bad things happen (but query works ok when run directly on database)
            /*
            SELECT "d"."Id", "d"."category", "d"."imageUrl", "d"."method", "d"."name", "d"."notes", "t"."dinnersId", "t"."ingredientsId", "t"."Id", "t"."imageUrl", "t"."name", "t"."quantity"
            FROM "dinners" AS "d"
            LEFT JOIN (
            SELECT "d0"."dinnersId", "d0"."ingredientsId", "i"."Id", "i"."imageUrl", "i"."name", "i"."quantity"
            FROM "DinnerIngredient" AS "d0"
            INNER JOIN "ingredients" AS "i" ON "d0"."ingredientsId" = "i"."Id"
            ) AS "t" ON "d"."Id" = "t"."dinnersId"
            ORDER BY "d"."Id", "t"."dinnersId", "t"."ingredientsId"
            */
            //return (await _db.dinners.Include(d => d.ingredients).ToListAsync()).OrderByDescending(d => d.name).ToList();

            // Nice big join between dinners, sides and ingredients
            /*
            SELECT "d"."Id", "d"."category", "d"."imageUrl", "d"."method", "d"."name", "d"."notes", "s"."Id", "s"."DinnerId", "s"."imageUrl", "s"."method", "s"."name", "s"."notes", "t"."dinnersId", "t"."ingredientsId", "t"."Id", "t"."imageUrl", "t"."name", "t"."quantity"
            FROM "dinners" AS "d"
            LEFT JOIN "sides" AS "s" ON "d"."Id" = "s"."DinnerId"
            LEFT JOIN (
            SELECT "d0"."dinnersId", "d0"."ingredientsId", "i"."Id", "i"."imageUrl", "i"."name", "i"."quantity"
            FROM "DinnerIngredient" AS "d0"
            INNER JOIN "ingredients" AS "i" ON "d0"."ingredientsId" = "i"."Id"
            ) AS "t" ON "d"."Id" = "t"."dinnersId"
            ORDER BY "d"."Id", "s"."Id", "t"."dinnersId", "t"."ingredientsId"
            */
            return (await _db.dinners.Include(d => d.sides).Include(d => d.ingredients).ToListAsync()).OrderByDescending(d => d.name).ToList();
        }

    }

}
