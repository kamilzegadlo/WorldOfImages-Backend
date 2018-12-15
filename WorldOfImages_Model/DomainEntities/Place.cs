using System.Collections.Generic;
using WorldOfImagesAPI_Model.ValueObjects;

namespace WorldOfImagesAPI_Model.DomainEntities
{
    public class Place
    {
        public Coordinates coordinates { get; private set; }
        public string name { get; private set; }
        public ICollection<Image> images { get; private set; }

        public Place(int x, int y, string name)
        {
            coordinates= new Coordinates(x,y);
            this.name = name;
            images = new List<Image>();
        }
    }
}
