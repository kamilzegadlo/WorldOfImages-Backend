using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorldOfImagesAPI.HttpRequestObjects
{
    public class AddImageRequest
    {
        public int x { get; set; }
        public int y { get; set; }
        public string image { get; set; }

        public AddImageRequest()
        {

        }
    }
}
