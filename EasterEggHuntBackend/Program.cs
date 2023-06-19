using Microsoft.EntityFrameworkCore;
using EasterEggHuntBackend.DbContext;
using EasterEggHuntBackend.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RiddleDbContext>(opts =>
{
    opts.UseSqlServer(
        builder.Configuration["ConnectionStrings:EasterEggHuntBackendConnection"]);
});

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.UseStaticFiles();

SeedData.EnsurePopulated(app);

app.Run();
