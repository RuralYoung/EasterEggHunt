namespace EasterEggHuntBackend.Models
{
    public interface IRiddleRepository
    {
        IQueryable<Riddle> Products { get; }
    }
}
