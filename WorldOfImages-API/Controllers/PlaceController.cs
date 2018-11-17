using Microsoft.AspNetCore.Mvc;
using WorldOfImagesAPI.ValueObjects;
using WorldOfImagesAPI.Repositories;
using System.Net;
using WorldOfImagesAPI.DomainEntities;

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

        public IActionResult Get(Coordinates getPlaceRequest)
        {
            var place = _placeRepository.GetPlace(getPlaceRequest);

            if (place == null)
                return new StatusCodeResult((int)HttpStatusCode.NotFound);

            return Ok(place);
        }

        public IActionResult Add(Place place)
        {
            _placeRepository.AddPlace(place);

            return new StatusCodeResult((int)HttpStatusCode.NoContent);
        }
    }
}
