using Microsoft.EntityFrameworkCore;
using EasterEggHuntBackend.Data;
using EasterEggHuntBackend;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RiddleDbContext>(opts =>
{
    opts.UseSqlServer(
        builder.Configuration["ConnectionStrings:EasterEggHuntBackendConnection"]);
});

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("AllowAnyOrigin", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.UseStaticFiles();

app.UseCors("AllowAnyOrigin");

SeedData.EnsurePopulated(app);

app.Run();
