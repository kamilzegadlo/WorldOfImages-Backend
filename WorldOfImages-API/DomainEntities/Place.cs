using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorldOfImagesAPI.DomainEntities
{
    public class Place
    {
        public int x { get; private set; }
        public int y { get; private set; }
        public string name { get; private set; }
        public ICollection<Image> images { get; private set; }

        public Place(int x, int y, string name)
        {
            this.x = x;
            this.y = y;
            this.name = name;
            images = new List<Image>();
        }
    }
}
