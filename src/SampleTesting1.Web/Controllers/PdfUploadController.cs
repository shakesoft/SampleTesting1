using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.BlobStoring;

namespace SampleTesting1.Controllers
{
    [Route("api/app/pdf-upload")]
    [Authorize]
    public class PdfUploadController : AbpController
    {
        private readonly IBlobContainer _blobContainer;

        public PdfUploadController(IBlobContainer blobContainer)
        {
            _blobContainer = blobContainer;
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest(new { error = "No file uploaded" });
            }

            if (!file.FileName.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase))
            {
                return BadRequest(new { error = "Only PDF files are allowed" });
            }

            try
            {
                var id = Guid.NewGuid();
                
                using (var stream = file.OpenReadStream())
                {
                    await _blobContainer.SaveAsync(id.ToString(), stream, overrideExisting: true);
                }

                return Ok(new { id, fileName = file.FileName });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Failed to upload PDF", details = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var stream = await _blobContainer.GetAsync(id.ToString());
                return File(stream, "application/pdf");
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
