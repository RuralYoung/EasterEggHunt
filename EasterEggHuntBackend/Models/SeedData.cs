using Microsoft.EntityFrameworkCore;

namespace EasterEggHuntBackend.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            RiddleDbContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<RiddleDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Riddles.Any())
            {
                context.Riddles.AddRange(
                    new Riddle
                    {
                        Question = "Who played the famous character Dr. Peter Venkman",
                        Answer = "Billy Murray",
                        Hint = "Murray Hill"
                    }
                );
            }
        }
    }
}
