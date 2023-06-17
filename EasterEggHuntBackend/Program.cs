using Microsoft.EntityFrameworkCore;
using EasterEggHuntBackend.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RiddleDbContext>(opts =>
{
    opts.UseSqlServer(
        builder.Configuration["ConnectionStrings:EasterEggHuntBackendConnection"]);
});

builder.Services.AddScoped<IRiddleRepository, EFRiddleRepository>();

// Defines the services that are required by the MVC framework
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.UseStaticFiles();

SeedData.EnsurePopulated(app);

app.Run();
