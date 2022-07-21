using Microsoft.EntityFrameworkCore;
using Pizza.API.Data;
using Pizza.API.Repository.Commands;
using Pizza.API.Schema.Mutations;
using Pizza.API.Schema.Queries;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>();

builder.Services.AddPooledDbContextFactory<PizzaDbContext>(options =>
{
    string dbConnection = builder.Configuration.GetConnectionString("default");
    options.UseSqlite(dbConnection);
});


builder.Services.AddScoped<IElementCommands, ElementCommands>();

var app = builder.Build();

app.UseRouting();

app.UseWebSockets();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});


using (IServiceScope scope = app.Services.CreateScope())
{
    IDbContextFactory<PizzaDbContext> contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<PizzaDbContext>>();

    using (PizzaDbContext context = contextFactory.CreateDbContext())
    {
        context.Database.Migrate();
    }
}

app.Run();


