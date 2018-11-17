using Microsoft.AspNetCore.Mvc;
using WorldOfImagesAPI.ValueObjects;
using WorldOfImagesAPI.DomainEntities;

namespace WorldOfImagesAPI.Controllers
{
    [Route("api/[controller]")]
    public class PlaceController : Controller
    {
        [HttpGet("{id}")]
        public Place Get(GetPlaceRequest getPlaceRequest)
        {
            return new Place();
        }
    }
}
