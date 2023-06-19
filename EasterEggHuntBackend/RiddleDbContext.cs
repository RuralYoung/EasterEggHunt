using EasterEggHuntBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace EasterEggHuntBackend
{
    public class RiddleDbContext : DbContext
    {
        public RiddleDbContext(DbContextOptions<RiddleDbContext> options)
            : base(options) { }

        public DbSet<Riddle> Riddles => Set<Riddle>();
    }
}
