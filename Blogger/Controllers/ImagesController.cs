﻿using Blogger.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Blogger.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImagesController : Controller
    {
        private readonly IImageRepository _imageRepository;

        public ImagesController(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            var imageUrl = await _imageRepository.Upload(file);

            if (imageUrl == null)
            {
                return Problem("Something went wrong.", null, (int)HttpStatusCode.InternalServerError);
            }
            return Json(new {link = imageUrl});
        }
    }
}
