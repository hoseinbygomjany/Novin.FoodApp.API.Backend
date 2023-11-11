using Microsoft.EntityFrameworkCore;
using Novin.FoodApp.Core.Entities;
using Novin.FoodApp.Infrastructure.Data;
using Novin.FoodApp.Infrastructure.Security;

var builder = WebApplication.CreateBuilder(args);

SecurityServices.AddServices(builder);

var app = builder.Build();
SecurityServices.UseServices(app);

app.MapPost("requestlist", async (NovinFoodAppDB db) =>
{
    return Results.Ok(db.Restaurants
        .Where(r => r.IsApproved == false)
        .ToList());
});
app.MapGet("/requestcount", async (NovinFoodAppDB db) =>
{
    return Results.Ok(new
    {
        Count = await db.Restaurants.CountAsync(r => r.IsApproved == false)
    });
});
app.Run();
