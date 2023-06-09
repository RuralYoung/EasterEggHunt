﻿using EasterEggHuntBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace EasterEggHuntBackend.Data
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
                        Answer = "Bill Murray",
                        Hint = "Ghostbusters",
                        ProgressCode = "06081984"
                    },
                    new Riddle
                    {
                        Question = "After the death of lead singer Bon Scott, what album did AC/DC release first?",
                        Answer = "Back in Black",
                        Hint = "This was album had a song of the same name which signified their bold new return under a new singer.",
                        ProgressCode = "07251980"
                    },
                    new Riddle
                    {
                        Question = "How many shapes are used in the game \"Tetris\"?",
                        Answer = "7",
                        Hint = "Mirrored pieces are counted as two seperate pieces.",
                        ProgressCode = "06061984"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
