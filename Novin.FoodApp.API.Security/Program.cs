using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Novin.FoodApp.API.Security.DTOs;
using Novin.FoodApp.Core.Entities;
using Novin.FoodApp.Core.Enumes;
using Novin.FoodApp.Core.Exceptions;
using Novin.FoodApp.Infrastructure.Data;
using Novin.FoodApp.Infrastructure.Security;
using System.ComponentModel;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

SecurityServices.AddServices(builder);

var app = builder.Build();

SecurityServices.UseServices(app);





app.MapPost("signup", async (NovinFoodAppDB db, RegisterRequestDto register) =>
{
    var user = new ApplicationUser();
    if (register.Username.Length <11)
    {
        throw new InvalidUsernameException();
    }
    user.Username=register.Username;
    if (register.Password.Length < 8)
    {
        throw new InvalidPasswordException();
    }
    user.Password=register.Password;
    user.Fullname =register.Fullname;
    user.Type =register.Type;
    var rg = new Random();
    user.VerificationCode = rg.Next(100000, 999999).ToString();
    await db.ApplicationUsers.AddAsync(user);
    try
    {
        await db.SaveChangesAsync();
    }
    catch 
    {
        throw new DuplicateUsernameExcepation(); 
    }
    return Results.Ok();
});
app.MapPost("signin", handler: async (NovinFoodAppDB db, LoginDto login) =>
{
    Thread.Sleep(3000);
    var result = await db.ApplicationUsers.FirstOrDefaultAsync(a => a.Type != ApplicationUserType.systemAdmin &&
    a.Verified == true &&
    a.Username == login.UserName &&
    a.Password == login.Password);
    if (result == null)
    {
        return Results.Ok(new LoginResultDto
        {
            Masseage = "نام کاربری یا کلمه عبور اشتباه است",
            Isok = false
        });
    }

    var claims = new[]
    {
        new Claim("Username",result.Username.ToString()),
        new Claim("Type",result.Type.ToString()),
    };
    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] ?? ""));
    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
    var token = new JwtSecurityToken(
        "Security.novinfood.com",
        "*.novinfood.com",
        claims,
        expires: DateTime.UtcNow.AddDays(1),
        signingCredentials: signIn);


    return Results.Ok(new LoginResultDto
    {
        Type = result.Type.ToString(),
        Masseage = "خوش امدید",
        Isok = true,
        Token = new JwtSecurityTokenHandler().WriteToken(token),
    });
});

app.MapPost("loginmanager", handler: async (NovinFoodAppDB db, LoginDto login) =>
{
    if (!db.ApplicationUsers.Any())
    {
        await db.ApplicationUsers.AddAsync(new ApplicationUser
        {
            Fullname = "مدریت سامانه",
            Username = "admin",
            Password = "admin",
            Type = ApplicationUserType.systemAdmin,
            Verified = true
        });
        await db.SaveChangesAsync();

    }
    Thread.Sleep(3000);
    var result = await db.ApplicationUsers.FirstOrDefaultAsync(a =>
    a.Type == ApplicationUserType.systemAdmin &&
    a.Verified == true && a.Username == login.UserName &&
    a.Password == login.Password);
    if (result == null)
    {
        return Results.Ok(new LoginResultDto
        {
            Masseage = "نام کاربری یا کلمه عبور اشتباه است",
            Isok = false
        });
    }

    var claims = new[]
    {
        new Claim("Username",result.Username.ToString()),
        new Claim("Type",result.Type.ToString()),
    };
    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] ?? ""));
    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
    var token = new JwtSecurityToken(
        "Security.novinfood.com",
        "*.novinfood.com",
        claims,
        expires: DateTime.UtcNow.AddDays(1),
        signingCredentials: signIn);


    return Results.Ok(new LoginResultDto
    {
        Type = result.Type.ToString(),
        Masseage = "خوش امدید",
        Isok = true,
        Token = new JwtSecurityTokenHandler().WriteToken(token),
    });
});

app.Run();