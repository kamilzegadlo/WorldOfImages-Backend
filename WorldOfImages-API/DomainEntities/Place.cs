using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldOfImagesAPI.HttpRequestObjects;
using WorldOfImagesAPI.ValueObjects;

namespace WorldOfImagesAPI.DomainEntities
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

        public Place(AddPlaceRequest addPlaceRequest)
        {
            coordinates = new Coordinates(addPlaceRequest.x, addPlaceRequest.y);
            name = addPlaceRequest.name;
            images = new List<Image>();
        }
    }
}
