using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorldOfImagesAPI.ValueObjects;

namespace WorldOfImages_API.Controllers
{
    [Route("api/[controller]")]
    public class PlaceController : Controller
    {
        [HttpGet("{id}")]
        public string Get(GetPlaceRequest getPlaceRequest)
        {
            return "fixedPlace";
        }
    }
}
