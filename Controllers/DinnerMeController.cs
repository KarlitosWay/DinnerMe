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
            return (await _db.dinners.ToListAsync()).OrderByDescending(d => d.name).ToList();
        }

    }
}
