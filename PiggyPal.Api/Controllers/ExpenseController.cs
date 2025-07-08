using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PiggyPal.Api.Models;

namespace PiggyPal.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpenseController : ControllerBase
    {
        private readonly PiggyPalContext _db;
        public ExpenseController(PiggyPalContext db) => _db = db;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _db.Expenses.ToListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var e = await _db.Expenses.FindAsync(id);
            return e is null ? NotFound() : Ok(e);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Expense expense)
        {
            _db.Expenses.Add(expense);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = expense.Id }, expense);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Expense input)
        {
            var e = await _db.Expenses.FindAsync(id);
            if (e is null) return NotFound();
            e.KidId = input.KidId;
            e.HouseholdId = input.HouseholdId;
            e.Amount = input.Amount;
            e.Description = input.Description;
            e.PictureUrl = input.PictureUrl;
            e.Date = input.Date;
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var e = await _db.Expenses.FindAsync(id);
            if (e is null) return NotFound();
            _db.Expenses.Remove(e);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
} 