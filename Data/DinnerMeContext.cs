using Microsoft.EntityFrameworkCore;

using DinnerMe.Model;


/**
 * Developer notes for myself...
 * Instructions for creating a database context can be found:
 * https://learn.microsoft.com/en-us/training/modules/interact-with-data-blazor-web-apps/5-exercise-access-data-from-blazor-components
 * 
 * Need to run the following in the terminal (from the solution directory) to add requisite packages.
 *   dotnet add package Microsoft.EntityFrameworkCore
 *   dotnet add package Microsoft.EntityFrameworkCore.Sqlite
 *   dotnet add package System.Net.Http.Json
 */

namespace DinnerMe.Data
{
    // This class creates a database context we can use to register a database service.
    // The context also allows us to have a controller that accesses the database (see DinnerMeController).
    public class DinnerMeContext : DbContext
    {
        public DinnerMeContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Dinner> dinners { get; set; }

        public DbSet<Category> categories { get; set; }

        public DbSet<Ingredient> ingredients { get; set; }

        public DbSet<Side> sides { get; set; }

    }

}
