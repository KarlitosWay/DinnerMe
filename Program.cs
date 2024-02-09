using DinnerMe.Components;
using DinnerMe.Data;

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
