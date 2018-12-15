using Microsoft.AspNetCore.Mvc;
using WorldOfImagesAPI.ValueObjects;
using WorldOfImagesAPI.Repositories;
using System.Net;
using WorldOfImagesAPI.DomainEntities;
using WorldOfImagesAPI.HttpRequestObjects;

namespace WorldOfImagesAPI.Controllers
{
    [Route("api/[controller]")]
    public class ImageController : Controller
    {
        private readonly IImageRepository _imageRepository;

        public ImageController(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        [HttpPost]
        public IActionResult Add([FromBody]AddImageRequest addImageRequest)
        {
            _imageRepository.AddImage(new Image(addImageRequest));

           return new StatusCodeResult((int)HttpStatusCode.NoContent);
        }
    }
}
