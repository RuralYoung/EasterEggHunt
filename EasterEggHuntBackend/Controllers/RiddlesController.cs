using Microsoft.AspNetCore.Mvc;
using EasterEggHuntBackend.Models;

namespace EasterEggHuntBackend.Controllers
{
    [Route("api/[controller]")]
    public class RiddlesController : Controller
    {
        private readonly RiddleDbContext _context;

        public RiddlesController(RiddleDbContext ctx)
        {
            _context = ctx;
        }

        [HttpGet]
        public IEnumerable<Riddle> GetRiddles()
        {
            return _context.Riddles.AsEnumerable<Riddle>();
        }

        [HttpGet("{id}")]
        public Riddle? GetRiddles(int id)
        {
            {
                return _context.Riddles.Where(r => r.Id == id).FirstOrDefault();
            }
        }
    }
}
