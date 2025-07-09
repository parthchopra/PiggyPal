using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PiggyPal.Api.Models;
using PiggyPal.Api.Services;
using System.Net;

namespace PiggyPal.Api.Controllers
{
    /// <summary>
    /// Manages behavior tracking for kids in the PiggyPal application.
    /// Tracks positive and negative behaviors, awards badges, and maintains behavior history.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class BehaviorController : ControllerBase
    {
        private readonly PiggyPalContext _db;
        private readonly GamificationService _gamification;
        public BehaviorController(PiggyPalContext db, GamificationService gamification) { _db = db; _gamification = gamification; }

        /// <summary>
        /// Retrieves all behaviors across all households
        /// </summary>
        /// <returns>List of all behaviors in the system</returns>
        /// <response code="200">Successfully retrieved all behaviors</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<Behavior>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll() => Ok(await _db.Behaviors.ToListAsync());

        /// <summary>
        /// Retrieves a specific behavior by its ID
        /// </summary>
        /// <param name="id">The unique identifier of the behavior</param>
        /// <returns>The behavior if found</returns>
        /// <response code="200">Successfully retrieved the behavior</response>
        /// <response code="404">Behavior not found</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Behavior), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var b = await _db.Behaviors.FindAsync(id);
            return b is null ? NotFound() : Ok(b);
        }

        /// <summary>
        /// Creates a new behavior record
        /// </summary>
        /// <param name="behavior">The behavior data to create</param>
        /// <returns>The created behavior with its ID</returns>
        /// <response code="201">Behavior successfully created</response>
        /// <response code="400">Invalid behavior data provided</response>
        [HttpPost]
        [ProducesResponseType(typeof(Behavior), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create(Behavior behavior)
        {
            _db.Behaviors.Add(behavior);
            await _db.SaveChangesAsync();
            if (behavior.IsPositive)
            {
                await _gamification.AwardBadgesForBehavior(behavior.KidId);
            }
            return CreatedAtAction(nameof(GetById), new { id = behavior.Id }, behavior);
        }

        /// <summary>
        /// Updates an existing behavior record
        /// </summary>
        /// <param name="id">The unique identifier of the behavior to update</param>
        /// <param name="input">The updated behavior data</param>
        /// <returns>No content on successful update</returns>
        /// <response code="204">Behavior successfully updated</response>
        /// <response code="404">Behavior not found</response>
        /// <response code="400">Invalid behavior data provided</response>
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Update(int id, Behavior input)
        {
            var b = await _db.Behaviors.FindAsync(id);
            if (b is null) return NotFound();
            b.Description = input.Description;
            b.KidId = input.KidId;
            b.HouseholdId = input.HouseholdId;
            b.Date = input.Date;
            b.RewardId = input.RewardId;
            b.IsPositive = input.IsPositive;
            b.Notes = input.Notes;
            await _db.SaveChangesAsync();
            return NoContent();
        }

        /// <summary>
        /// Deletes a behavior record
        /// </summary>
        /// <param name="id">The unique identifier of the behavior to delete</param>
        /// <returns>No content on successful deletion</returns>
        /// <response code="204">Behavior successfully deleted</response>
        /// <response code="404">Behavior not found</response>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var b = await _db.Behaviors.FindAsync(id);
            if (b is null) return NotFound();
            _db.Behaviors.Remove(b);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
} 