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
                        Hint = "Ghostbusters"
                    },
                    new Riddle
                    {
                        Question = "After the death of lead singer Bon Scott, what album did AC/DC release first?",
                        Answer = "Back in Black",
                        Hint = "This was album had a song of the same name which signified their bold new return under a new singer."
                    },
                    new Riddle
                    {
                        Question = "How many shapes are used in the game \"Tetris\"?",
                        Answer = "Seven",
                        Hint = "Mirrored pieces are counted as two seperate pieces."
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
