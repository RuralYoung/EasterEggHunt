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

        [HttpGet("{ProgressCode}")]
        public Riddle? GetRiddles(string ProgressCode)
        {
            {
                return _context.Riddles.Where(r => r.ProgressCode == ProgressCode).FirstOrDefault();
            }
        }
    }
}
