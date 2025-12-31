using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.BlobStoring;

namespace SampleTesting1.Web.Public.Controllers
{
    [Route("api/app/pdf-upload")]
    public class PdfUploadController : AbpController
    {
        private readonly IBlobContainer _blobContainer;

        public PdfUploadController(IBlobContainer blobContainer)
        {
            _blobContainer = blobContainer;
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
