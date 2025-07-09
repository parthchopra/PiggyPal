using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PiggyPal.Api.Models;
using PiggyPal.Api.Services;
using System.Net;

namespace PiggyPal.Api.Controllers
{
    /// <summary>
    /// Manages chores assigned to kids in the PiggyPal application.
    /// Handles chore creation, assignment, completion tracking, and reward integration.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ChoreController : ControllerBase
    {
        private readonly PiggyPalContext _db;
        private readonly GamificationService _gamification;
        public ChoreController(PiggyPalContext db, GamificationService gamification) { _db = db; _gamification = gamification; }

        /// <summary>
        /// Retrieves all chores across all households
        /// </summary>
        /// <returns>List of all chores in the system</returns>
        /// <response code="200">Successfully retrieved all chores</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<Chore>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll() => Ok(await _db.Chores.ToListAsync());

        /// <summary>
        /// Retrieves a specific chore by its ID
        /// </summary>
        /// <param name="id">The unique identifier of the chore</param>
        /// <returns>The chore if found</returns>
        /// <response code="200">Successfully retrieved the chore</response>
        /// <response code="404">Chore not found</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Chore), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var c = await _db.Chores.FindAsync(id);
            return c is null ? NotFound() : Ok(c);
        }

        /// <summary>
        /// Creates a new chore assignment
        /// </summary>
        /// <param name="chore">The chore data to create</param>
        /// <returns>The created chore with its ID</returns>
        /// <response code="201">Chore successfully created</response>
        /// <response code="400">Invalid chore data provided</response>
        [HttpPost]
        [ProducesResponseType(typeof(Chore), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create(Chore chore)
        {
            _db.Chores.Add(chore);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = chore.Id }, chore);
        }

        /// <summary>
        /// Updates an existing chore assignment
        /// </summary>
        /// <param name="id">The unique identifier of the chore to update</param>
        /// <param name="input">The updated chore data</param>
        /// <returns>No content on successful update</returns>
        /// <response code="204">Chore successfully updated</response>
        /// <response code="404">Chore not found</response>
        /// <response code="400">Invalid chore data provided</response>
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
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

        /// <summary>
        /// Deletes a chore assignment
        /// </summary>
        /// <param name="id">The unique identifier of the chore to delete</param>
        /// <returns>No content on successful deletion</returns>
        /// <response code="204">Chore successfully deleted</response>
        /// <response code="404">Chore not found</response>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
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