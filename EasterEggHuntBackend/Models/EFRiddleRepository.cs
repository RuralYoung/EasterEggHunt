namespace EasterEggHuntBackend.Models
{
    public class EFRiddleRepository : IRiddleRepository
    {
        private RiddleDbContext context;

        public EFRiddleRepository(RiddleDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Riddle> Riddles => context.Riddles;
    }
}
