using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PiggyPal.Api.Models;
using PiggyPal.Api.Services;

namespace PiggyPal.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BehaviorController : ControllerBase
    {
        private readonly PiggyPalContext _db;
        private readonly GamificationService _gamification;
        public BehaviorController(PiggyPalContext db, GamificationService gamification) { _db = db; _gamification = gamification; }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _db.Behaviors.ToListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var b = await _db.Behaviors.FindAsync(id);
            return b is null ? NotFound() : Ok(b);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Behavior behavior)
        {
            _db.Behaviors.Add(behavior);
            await _db.SaveChangesAsync();
            if (behavior.IsPositive)
            {
                await _gamification.AwardBadgesForBehavior(behavior.KidId);
            }
            return CreatedAtAction(nameof(GetById), new { id = behavior.Id }, behavior);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Behavior input)
        {
            var b = await _db.Behaviors.FindAsync(id);
            if (b is null) return NotFound();
            b.Description = input.Description;
            b.KidId = input.KidId;
            b.HouseholdId = input.HouseholdId;
            b.Date = input.Date;
            b.RewardId = input.RewardId;
            b.IsPositive = input.IsPositive;
            b.Notes = input.Notes;
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var b = await _db.Behaviors.FindAsync(id);
            if (b is null) return NotFound();
            _db.Behaviors.Remove(b);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
} 