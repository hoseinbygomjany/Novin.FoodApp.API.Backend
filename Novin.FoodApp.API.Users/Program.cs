using Novin.FoodApp.Infrastructure.Data;
using Novin.FoodApp.Infrastructure.Security;
using Novin.FoodApp.Infrastructure.UI;

var builder = WebApplication.CreateBuilder(args);

SecurityServices.AddServices(builder);

var app = builder.Build();
SecurityServices.UseServices(app);
app.MapPost("list", async (NovinFoodAppDB db) =>
{
    return Results.Ok(db.ApplicationUsers
        .ToList());
});
app.MapPost("alist", async (NovinFoodAppDB db , ListRequestDto listRequest) =>
{
    return Results.Ok(db.ApplicationUsers
        .ToList());
});
app.Run();

