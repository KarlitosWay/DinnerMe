using Microsoft.EntityFrameworkCore;

using DinnerMe.Model;
using System.Reflection.Metadata;


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

        public DbSet<Ingredient> ingredients { get; set; }

        public DbSet<Side> sides { get; set; }

        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Dinner>().HasMany(e => e.ingredients)
                                         .WithOne(e => e.)

            modelBuilder.Entity<Blog>()
                    .HasMany(e => e.Posts)
                    .WithOne(e => e.Blog)
                    .HasForeignKey(e => e.BlogId)
                    .HasPrincipalKey(e => e.Id);

            // Configuring a many-to-many special -> topping relationship that is friendly for serialization
            modelBuilder.Entity<PizzaTopping>().HasKey(pst => new { pst.PizzaId, pst.ToppingId });
            modelBuilder.Entity<PizzaTopping>().HasOne<Pizza>().WithMany(ps => ps.Toppings);
            modelBuilder.Entity<PizzaTopping>().HasOne(pst => pst.Topping).WithMany();
        }
        */
    }

}
