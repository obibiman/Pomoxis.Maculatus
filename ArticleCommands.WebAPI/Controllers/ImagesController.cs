using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleCommands.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IHostEnvironment _ihostEnvironment;

        public ImagesController(IHostEnvironment ihostEnvironment)
        {
            _ihostEnvironment = ihostEnvironment;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] IFormFile image)
        {
            if (image == null || image.Length == 0)
            {
                return BadRequest("You must uplad a file");
            }

            var fileName = image.FileName;
            var extension = Path.GetExtension(fileName);
            string[] allowedExtensions = { ".bmp", ".png", ".jpg" };

            if (!allowedExtensions.Contains(extension))
            {
                return BadRequest("Uploaded file is not a valid image");
            }

            var newFilename = $"{Guid.NewGuid()}{extension}";
            var filePath = Path.Combine(_ihostEnvironment.ContentRootPath, "wwwroot", "Images", newFilename);

            using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                await image.CopyToAsync(fileStream);
            }
            return Ok($"Images/{newFilename}");
        }
    }
}