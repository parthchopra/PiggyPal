using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PiggyPal.Api.Models;
using PiggyPal.Api.Services;

namespace PiggyPal.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChoreController : ControllerBase
    {
        private readonly PiggyPalContext _db;
        private readonly GamificationService _gamification;
        public ChoreController(PiggyPalContext db, GamificationService gamification) { _db = db; _gamification = gamification; }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _db.Chores.ToListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var c = await _db.Chores.FindAsync(id);
            return c is null ? NotFound() : Ok(c);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Chore chore)
        {
            _db.Chores.Add(chore);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = chore.Id }, chore);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Chore input)
        {
            var c = await _db.Chores.FindAsync(id);
            if (c is null) return NotFound();
            bool wasApproved = c.Status == ChoreStatus.Approved;
            c.Description = input.Description;
            c.PictureUrl = input.PictureUrl;
            c.AssignedToKidId = input.AssignedToKidId;
            c.HouseholdId = input.HouseholdId;
            c.AssignedDate = input.AssignedDate;
            c.CompletedDate = input.CompletedDate;
            c.Status = input.Status;
            c.SubmittedPictureUrl = input.SubmittedPictureUrl;
            c.ApprovedByParentId = input.ApprovedByParentId;
            c.RewardId = input.RewardId;
            c.Notes = input.Notes;
            await _db.SaveChangesAsync();
            if (c.Status == ChoreStatus.Approved && !wasApproved && c.AssignedToKidId.HasValue)
            {
                await _gamification.AwardBadgesForChore(c.AssignedToKidId.Value);
                await _gamification.UpdateStreaks(c.AssignedToKidId.Value);
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var c = await _db.Chores.FindAsync(id);
            if (c is null) return NotFound();
            _db.Chores.Remove(c);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
} 