using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PiggyPal.Api.Models;

namespace PiggyPal.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParentController : ControllerBase
    {
        private readonly PiggyPalContext _db;
        public ParentController(PiggyPalContext db) => _db = db;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _db.Parents.ToListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var p = await _db.Parents.FindAsync(id);
            return p is null ? NotFound() : Ok(p);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Parent parent)
        {
            _db.Parents.Add(parent);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = parent.Id }, parent);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Parent input)
        {
            var p = await _db.Parents.FindAsync(id);
            if (p is null) return NotFound();
            p.Name = input.Name;
            p.Email = input.Email;
            p.ProfilePictureUrl = input.ProfilePictureUrl;
            p.HouseholdId = input.HouseholdId;
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var p = await _db.Parents.FindAsync(id);
            if (p is null) return NotFound();
            _db.Parents.Remove(p);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
} 