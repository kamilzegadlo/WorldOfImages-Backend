using Microsoft.AspNetCore.Mvc;
using WorldOfImagesAPI.ValueObjects;
using WorldOfImagesAPI.DomainEntities;
using WorldOfImagesAPI.Repositories;

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

        public Place Get(Coordinates getPlaceRequest)
        {
            return _placeRepository.GetPlace(getPlaceRequest);
        }
    }
}
