using DinnerMe.Components;
using DinnerMe.Data;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

//
// Add services to the container.
//
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
// Allow the app to access HTTP commands. The app uses an HttpClient to get the JSON for dinners.
builder.Services.AddHttpClient();
//  Register the new DinnerMeContext and provide the filename for the SQLite database.
// TODO, shouldn't be hardcoded.
builder.Services.AddSqlite<DinnerMeContext>("Data Source=SQLiteDB/dinnerme.db");

// Note: I had to add this to get the call to MapControllerRoute() to work, otherwise I got
// an "unable to find the required services" exception
builder.Services.AddControllersWithViews();

// TODO, added this because JSON couldn't handle the many-to-many relationship between Model.Dinner and Model.Ingredient.
// Is this really the best way or is my model broken?
// See https://stackoverflow.com/questions/59199593/net-core-3-0-possible-object-cycle-was-detected-which-is-not-supported
builder.Services.AddControllersWithViews()
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Note: TODO, added this to fix routing to https://<host>:<port>/dinners. I don't know how/why this works?
app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

// Initialize the database.
// Ceates a database scope with the DinnerMeContext.
// If there isn't a database already created, it calls the SeedData static class to create one.
var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<DinnerMeContext>();
    if (db.Database.EnsureCreated())
    {
        SeedData.Initialize(db);
    }
}

app.Run();
