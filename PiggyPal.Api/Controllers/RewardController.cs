using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PiggyPal.Api.Models;

namespace PiggyPal.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RewardController : ControllerBase
    {
        private readonly PiggyPalContext _db;
        public RewardController(PiggyPalContext db) => _db = db;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _db.Rewards.ToListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var r = await _db.Rewards.FindAsync(id);
            return r is null ? NotFound() : Ok(r);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Reward reward)
        {
            _db.Rewards.Add(reward);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = reward.Id }, reward);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Reward input)
        {
            var r = await _db.Rewards.FindAsync(id);
            if (r is null) return NotFound();
            r.Type = input.Type;
            r.Amount = input.Amount;
            r.Description = input.Description;
            r.ChoreId = input.ChoreId;
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var r = await _db.Rewards.FindAsync(id);
            if (r is null) return NotFound();
            _db.Rewards.Remove(r);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
} 