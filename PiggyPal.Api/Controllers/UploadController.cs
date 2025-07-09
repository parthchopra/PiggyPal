using Microsoft.AspNetCore.Mvc;
using PiggyPal.Api.Models;
using System.Net;

namespace PiggyPal.Api.Controllers
{
    /// <summary>
    /// Handles file uploads for the PiggyPal application.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class UploadController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        public UploadController(IWebHostEnvironment env)
        {
            _env = env;
        }

        /// <summary>
        /// Uploads a file to the server.
        /// </summary>
        /// <param name="request">The file upload request.</param>
        /// <returns>URL of the uploaded file.</returns>
        /// <response code="200">File uploaded successfully</response>
        /// <response code="400">No file uploaded</response>
        [HttpPost]
        [ProducesResponseType(typeof(object), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Upload([FromForm] UploadFileRequest request)
        {
            var file = request.File;
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            var uploadsPath = Path.Combine(_env.ContentRootPath, "Uploads");
            if (!Directory.Exists(uploadsPath))
                Directory.CreateDirectory(uploadsPath);

            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadsPath, fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            var fileUrl = $"/Uploads/{fileName}";
            return Ok(new { url = fileUrl });
        }
    }
} 