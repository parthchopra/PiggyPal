using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PiggyPal.Api.Models;

namespace PiggyPal.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KidController : ControllerBase
    {
        private readonly PiggyPalContext _db;
        public KidController(PiggyPalContext db) => _db = db;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _db.Kids.ToListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var k = await _db.Kids.FindAsync(id);
            return k is null ? NotFound() : Ok(k);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Kid kid)
        {
            _db.Kids.Add(kid);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = kid.Id }, kid);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Kid input)
        {
            var k = await _db.Kids.FindAsync(id);
            if (k is null) return NotFound();
            k.Name = input.Name;
            k.ProfilePictureUrl = input.ProfilePictureUrl;
            k.HouseholdId = input.HouseholdId;
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var k = await _db.Kids.FindAsync(id);
            if (k is null) return NotFound();
            _db.Kids.Remove(k);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
} 