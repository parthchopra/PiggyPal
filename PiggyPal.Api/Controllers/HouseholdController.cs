using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PiggyPal.Api.Models;

namespace PiggyPal.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HouseholdController : ControllerBase
    {
        private readonly PiggyPalContext _db;
        public HouseholdController(PiggyPalContext db) => _db = db;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _db.Households.ToListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var h = await _db.Households.FindAsync(id);
            return h is null ? NotFound() : Ok(h);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Household household)
        {
            _db.Households.Add(household);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = household.Id }, household);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Household input)
        {
            var h = await _db.Households.FindAsync(id);
            if (h is null) return NotFound();
            h.Name = input.Name;
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var h = await _db.Households.FindAsync(id);
            if (h is null) return NotFound();
            _db.Households.Remove(h);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
} 