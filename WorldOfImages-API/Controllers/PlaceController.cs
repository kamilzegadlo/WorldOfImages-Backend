using Microsoft.AspNetCore.Mvc;
using WorldOfImagesAPI.ValueObjects;
using WorldOfImagesAPI.DomainEntities;

namespace WorldOfImagesAPI.Controllers
{
    [Route("api/[controller]")]
    public class PlaceController : Controller
    {
        public Place Get(Coordinates getPlaceRequest)
        {
            return new Place(getPlaceRequest.x, getPlaceRequest.y, "unit test name");
        }
    }
}
