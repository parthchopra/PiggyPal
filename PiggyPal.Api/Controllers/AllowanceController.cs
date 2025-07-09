using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PiggyPal.Api.Models;
using System.Net;

namespace PiggyPal.Api.Controllers
{
    /// <summary>
    /// Manages allowance tracking for kids in the PiggyPal application.
    /// Handles allowance creation, scheduling, and payment tracking.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class AllowanceController : ControllerBase
    {
        private readonly PiggyPalContext _db;
        public AllowanceController(PiggyPalContext db) => _db = db;

        /// <summary>
        /// Retrieves all allowances across all households
        /// </summary>
        /// <returns>List of all allowances in the system</returns>
        /// <response code="200">Successfully retrieved all allowances</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<Allowance>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll() => Ok(await _db.Allowances.ToListAsync());

        /// <summary>
        /// Retrieves a specific allowance by its ID
        /// </summary>
        /// <param name="id">The unique identifier of the allowance</param>
        /// <returns>The allowance if found</returns>
        /// <response code="200">Successfully retrieved the allowance</response>
        /// <response code="404">Allowance not found</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Allowance), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var a = await _db.Allowances.FindAsync(id);
            return a is null ? NotFound() : Ok(a);
        }

        /// <summary>
        /// Creates a new allowance record
        /// </summary>
        /// <param name="allowance">The allowance data to create</param>
        /// <returns>The created allowance with its ID</returns>
        /// <response code="201">Allowance successfully created</response>
        /// <response code="400">Invalid allowance data provided</response>
        [HttpPost]
        [ProducesResponseType(typeof(Allowance), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create(Allowance allowance)
        {
            _db.Allowances.Add(allowance);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = allowance.Id }, allowance);
        }

        /// <summary>
        /// Updates an existing allowance record
        /// </summary>
        /// <param name="id">The unique identifier of the allowance to update</param>
        /// <param name="input">The updated allowance data</param>
        /// <returns>No content on successful update</returns>
        /// <response code="204">Allowance successfully updated</response>
        /// <response code="404">Allowance not found</response>
        /// <response code="400">Invalid allowance data provided</response>
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
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

        /// <summary>
        /// Deletes an allowance record
        /// </summary>
        /// <param name="id">The unique identifier of the allowance to delete</param>
        /// <returns>No content on successful deletion</returns>
        /// <response code="204">Allowance successfully deleted</response>
        /// <response code="404">Allowance not found</response>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
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