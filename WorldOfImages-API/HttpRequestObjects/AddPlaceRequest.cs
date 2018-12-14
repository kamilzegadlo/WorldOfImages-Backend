using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorldOfImagesAPI.HttpRequestObjects
{
    public class AddPlaceRequest
    {
        public string name { get; set; }
        public int x { get; set; }
        public int y { get; set; }

        public AddPlaceRequest()
        {

        }
    }
}
