using Microsoft.AspNetCore.Http;

namespace PiggyPal.Api.Models
{
    /// <summary>
    /// Request model for uploading a file.
    /// </summary>
    public class UploadFileRequest
    {
        /// <summary>
        /// The file to upload.
        /// </summary>
        public IFormFile File { get; set; }
    }
} 