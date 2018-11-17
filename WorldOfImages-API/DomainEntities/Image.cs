using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorldOfImagesAPI.DomainEntities
{
    public class Image
    {
        public long id { get; private set;}
        public string image { get; private set; }

        public Image(long id, string image)
        {
            this.id = id;
            this.image = image;
        }

    }
}
