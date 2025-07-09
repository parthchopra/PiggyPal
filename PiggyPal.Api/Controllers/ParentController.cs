using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PiggyPal.Api.Models;
using System.Net;

namespace PiggyPal.Api.Controllers
{
    /// <summary>
    /// Manages parent profiles in the PiggyPal application.
    /// Handles parent registration, profile management, and household associations.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ParentController : ControllerBase
    {
        private readonly PiggyPalContext _db;
        public ParentController(PiggyPalContext db) => _db = db;

        /// <summary>
        /// Retrieves all parents across all households
        /// </summary>
        /// <returns>List of all parents in the system</returns>
        /// <response code="200">Successfully retrieved all parents</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<Parent>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll() => Ok(await _db.Parents.ToListAsync());

        /// <summary>
        /// Retrieves a specific parent by their ID
        /// </summary>
        /// <param name="id">The unique identifier of the parent</param>
        /// <returns>The parent if found</returns>
        /// <response code="200">Successfully retrieved the parent</response>
        /// <response code="404">Parent not found</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Parent), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var p = await _db.Parents.FindAsync(id);
            return p is null ? NotFound() : Ok(p);
        }

        /// <summary>
        /// Creates a new parent profile
        /// </summary>
        /// <param name="parent">The parent data to create</param>
        /// <returns>The created parent with their ID</returns>
        /// <response code="201">Parent successfully created</response>
        /// <response code="400">Invalid parent data provided</response>
        [HttpPost]
        [ProducesResponseType(typeof(Parent), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create(Parent parent)
        {
            _db.Parents.Add(parent);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = parent.Id }, parent);
        }

        /// <summary>
        /// Updates an existing parent profile
        /// </summary>
        /// <param name="id">The unique identifier of the parent to update</param>
        /// <param name="input">The updated parent data</param>
        /// <returns>No content on successful update</returns>
        /// <response code="204">Parent successfully updated</response>
        /// <response code="404">Parent not found</response>
        /// <response code="400">Invalid parent data provided</response>
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
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

        /// <summary>
        /// Deletes a parent profile
        /// </summary>
        /// <param name="id">The unique identifier of the parent to delete</param>
        /// <returns>No content on successful deletion</returns>
        /// <response code="204">Parent successfully deleted</response>
        /// <response code="404">Parent not found</response>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
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