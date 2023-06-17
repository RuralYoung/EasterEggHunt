using Microsoft.EntityFrameworkCore;

namespace EasterEggHuntBackend.Models
{
    public class RiddleDbContext : DbContext
    {
        public RiddleDbContext( DbContextOptions<RiddleDbContext> options )
            : base( options) { }

        public DbSet<Riddle> Ridles => Set<Riddle>();
    }
}
