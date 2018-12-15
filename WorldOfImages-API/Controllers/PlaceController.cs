using Microsoft.AspNetCore.Mvc;
using WorldOfImagesAPI_Model.ValueObjects;
using WorldOfImagesAPI_Model.Repositories;
using System.Net;
using WorldOfImagesAPI_Model.DomainEntities;
using WorldOfImagesAPI.HttpRequestObjects;

namespace WorldOfImagesAPI.Controllers
{
    [Route("api/[controller]")]
    public class PlaceController : Controller
    {
        private readonly IPlaceRepository _placeRepository;

        public PlaceController(IPlaceRepository placeRepository)
        {
            _placeRepository = placeRepository;
        }

        [HttpGet]
        public IActionResult Get(GetPlaceRequest getPlaceRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var place = _placeRepository.GetPlace(new Coordinates(getPlaceRequest.x, getPlaceRequest.y));

            if (place == null)
                return new StatusCodeResult((int)HttpStatusCode.NotFound);

            return Ok(place);
        }

        [HttpPost]
        public IActionResult Add([FromBody]AddPlaceRequest place)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _placeRepository.AddPlace(new Place(place.x, place.y, place.name));

            return new StatusCodeResult((int)HttpStatusCode.NoContent);
        }
    }
}
