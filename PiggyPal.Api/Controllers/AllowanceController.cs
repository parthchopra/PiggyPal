using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PiggyPal.Api.Models;

namespace PiggyPal.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AllowanceController : ControllerBase
    {
        private readonly PiggyPalContext _db;
        public AllowanceController(PiggyPalContext db) => _db = db;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _db.Allowances.ToListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var a = await _db.Allowances.FindAsync(id);
            return a is null ? NotFound() : Ok(a);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Allowance allowance)
        {
            _db.Allowances.Add(allowance);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = allowance.Id }, allowance);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Allowance input)
        {
            var a = await _db.Allowances.FindAsync(id);
            if (a is null) return NotFound();
            a.KidId = input.KidId;
            a.HouseholdId = input.HouseholdId;
            a.Amount = input.Amount;
            a.Cadence = input.Cadence;
            a.StartDate = input.StartDate;
            a.EndDate = input.EndDate;
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var a = await _db.Allowances.FindAsync(id);
            if (a is null) return NotFound();
            _db.Allowances.Remove(a);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
} 