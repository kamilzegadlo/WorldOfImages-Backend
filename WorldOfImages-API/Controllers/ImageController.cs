using Microsoft.AspNetCore.Mvc;
using WorldOfImagesAPI_Model.Repositories;
using System.Net;
using WorldOfImagesAPI_Model.DomainEntities;
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
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _imageRepository.AddImage(new Image(addImageRequest.x, addImageRequest.y, addImageRequest.image));

           return new StatusCodeResult((int)HttpStatusCode.NoContent);
        }
    }
}
