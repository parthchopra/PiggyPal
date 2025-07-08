using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PiggyPal.Api.Models;

namespace PiggyPal.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BadgeController : ControllerBase
    {
        private readonly PiggyPalContext _db;
        public BadgeController(PiggyPalContext db) => _db = db;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _db.Badges.ToListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var b = await _db.Badges.FindAsync(id);
            return b is null ? NotFound() : Ok(b);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Badge badge)
        {
            _db.Badges.Add(badge);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = badge.Id }, badge);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Badge input)
        {
            var b = await _db.Badges.FindAsync(id);
            if (b is null) return NotFound();
            b.Name = input.Name;
            b.Description = input.Description;
            b.IconUrl = input.IconUrl;
            b.KidId = input.KidId;
            b.DateAwarded = input.DateAwarded;
            b.HouseholdId = input.HouseholdId;
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var b = await _db.Badges.FindAsync(id);
            if (b is null) return NotFound();
            _db.Badges.Remove(b);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
} 