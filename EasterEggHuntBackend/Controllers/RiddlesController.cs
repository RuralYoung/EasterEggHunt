﻿using Microsoft.AspNetCore.Mvc;
using EasterEggHuntBackend.Models;

namespace EasterEggHuntBackend.Controllers
{
    [Route("api/[controller]")]
    public class RiddlesController : Controller
    {
        private IRiddleRepository repository;

        public RiddlesController(IRiddleRepository repo)
        {
            repository = repo;
        }

        [HttpGet]
        public IEnumerable<Riddle> GetRiddles()
        {
            return repository.Riddles.AsEnumerable<Riddle>();
        }

        [HttpGet("{id}")]
        public Riddle? GetRiddles(int id)
        {
            {
                return repository.Riddles.Where(r =>r.Id == id).FirstOrDefault();
            }
        }
    }
}
