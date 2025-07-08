using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PiggyPal.Api.Models;

namespace PiggyPal.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StreakController : ControllerBase
    {
        private readonly PiggyPalContext _db;
        public StreakController(PiggyPalContext db) => _db = db;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _db.Streaks.ToListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var s = await _db.Streaks.FindAsync(id);
            return s is null ? NotFound() : Ok(s);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Streak streak)
        {
            _db.Streaks.Add(streak);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = streak.Id }, streak);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Streak input)
        {
            var s = await _db.Streaks.FindAsync(id);
            if (s is null) return NotFound();
            s.KidId = input.KidId;
            s.HouseholdId = input.HouseholdId;
            s.Type = input.Type;
            s.StartDate = input.StartDate;
            s.EndDate = input.EndDate;
            s.Length = input.Length;
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var s = await _db.Streaks.FindAsync(id);
            if (s is null) return NotFound();
            _db.Streaks.Remove(s);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
} 