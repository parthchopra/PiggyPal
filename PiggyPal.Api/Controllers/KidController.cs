using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PiggyPal.Api.Models;
using System.Net;

namespace PiggyPal.Api.Controllers
{
    /// <summary>
    /// Manages kid profiles in the PiggyPal application.
    /// Handles kid registration, profile management, and household associations.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class KidController : ControllerBase
    {
        private readonly PiggyPalContext _db;
        public KidController(PiggyPalContext db) => _db = db;

        /// <summary>
        /// Retrieves all kids across all households
        /// </summary>
        /// <returns>List of all kids in the system</returns>
        /// <response code="200">Successfully retrieved all kids</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<Kid>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll() => Ok(await _db.Kids.ToListAsync());

        /// <summary>
        /// Retrieves a specific kid by their ID
        /// </summary>
        /// <param name="id">The unique identifier of the kid</param>
        /// <returns>The kid if found</returns>
        /// <response code="200">Successfully retrieved the kid</response>
        /// <response code="404">Kid not found</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Kid), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var k = await _db.Kids.FindAsync(id);
            return k is null ? NotFound() : Ok(k);
        }

        /// <summary>
        /// Creates a new kid profile
        /// </summary>
        /// <param name="kid">The kid data to create</param>
        /// <returns>The created kid with their ID</returns>
        /// <response code="201">Kid successfully created</response>
        /// <response code="400">Invalid kid data provided</response>
        [HttpPost]
        [ProducesResponseType(typeof(Kid), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create(Kid kid)
        {
            _db.Kids.Add(kid);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = kid.Id }, kid);
        }

        /// <summary>
        /// Updates an existing kid profile
        /// </summary>
        /// <param name="id">The unique identifier of the kid to update</param>
        /// <param name="input">The updated kid data</param>
        /// <returns>No content on successful update</returns>
        /// <response code="204">Kid successfully updated</response>
        /// <response code="404">Kid not found</response>
        /// <response code="400">Invalid kid data provided</response>
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
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

        /// <summary>
        /// Deletes a kid profile
        /// </summary>
        /// <param name="id">The unique identifier of the kid to delete</param>
        /// <returns>No content on successful deletion</returns>
        /// <response code="204">Kid successfully deleted</response>
        /// <response code="404">Kid not found</response>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
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