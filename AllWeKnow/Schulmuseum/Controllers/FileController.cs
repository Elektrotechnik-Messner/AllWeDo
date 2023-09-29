using System.Net;
using Microsoft.AspNetCore.Mvc;
using Schulmuseum.Models;

namespace Schulmuseum.Controllers
{
    
    public class FileController : Controller
    {
        private readonly IWebHostEnvironment _env; 
        
        public FileController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [HttpPost]
        public async Task<ActionResult<List<UploadResult>>> UploadFile(List<IFormFile> files)
        {
            List<UploadResult> uploadResults = new List<UploadResult>();

            foreach (var file in files)
            {
                var uploadResult = new UploadResult();
                var untrustedFileName = file.FileName;
                uploadResult.FileName = untrustedFileName;
                var trustedFileNameForDisplay = WebUtility.HtmlEncode(untrustedFileName);

                var trustedFileNameForFileStorage = Path.GetRandomFileName();
                var path = Path.Combine(_env.ContentRootPath, "Shared", trustedFileNameForFileStorage);

                await using FileStream fs = new(path, FileMode.Create);
                await file.CopyToAsync(fs);

                uploadResult.StroredFileName = trustedFileNameForFileStorage;
                uploadResults.Add(uploadResult);
            }

            return Ok(uploadResults);
        }
    }
}