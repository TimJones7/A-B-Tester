using Microsoft.EntityFrameworkCore;
using Pizza.API.Data;

var builder = WebApplication.CreateBuilder(args);





builder.Services.AddPooledDbContextFactory<PizzaDbContext>(options =>
{
    string dbConnection = builder.Configuration.GetConnectionString("default");
    options.UseSqlite(dbConnection);
});


var app = builder.Build();

app.MapGet("/", () => "Hello World!");






using (IServiceScope scope = app.Services.CreateScope())
{
    IDbContextFactory<PizzaDbContext> contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<PizzaDbContext>>();

    using (PizzaDbContext context = contextFactory.CreateDbContext())
    {
        context.Database.Migrate();
    }
}

app.Run();
