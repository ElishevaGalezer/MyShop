using Microsoft.EntityFrameworkCore;

using Repositories;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepositories, UserRepositories>();
builder.Services.AddDbContext<MyShopUsersContext>(options => options.UseSqlServer("Server=SRV2\\PUPILS;Database=MyShopUsers;Trusted_Connection=True;TrustServerCertificate=True"));

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
