namespace EasterEggHuntBackend.Models
{
    public interface IRiddleRepository
    {
        IQueryable<Riddle> Riddles { get; }
    }
}
