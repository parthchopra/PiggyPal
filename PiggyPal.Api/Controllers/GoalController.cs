using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PiggyPal.Api.Models;

namespace PiggyPal.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GoalController : ControllerBase
    {
        private readonly PiggyPalContext _db;
        public GoalController(PiggyPalContext db) => _db = db;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _db.Goals.ToListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var g = await _db.Goals.FindAsync(id);
            return g is null ? NotFound() : Ok(g);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Goal goal)
        {
            _db.Goals.Add(goal);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = goal.Id }, goal);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Goal input)
        {
            var g = await _db.Goals.FindAsync(id);
            if (g is null) return NotFound();
            g.KidId = input.KidId;
            g.HouseholdId = input.HouseholdId;
            g.Description = input.Description;
            g.TargetAmount = input.TargetAmount;
            g.CurrentAmount = input.CurrentAmount;
            g.PictureUrl = input.PictureUrl;
            g.CreatedDate = input.CreatedDate;
            g.CompletedDate = input.CompletedDate;
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var g = await _db.Goals.FindAsync(id);
            if (g is null) return NotFound();
            _db.Goals.Remove(g);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
} 