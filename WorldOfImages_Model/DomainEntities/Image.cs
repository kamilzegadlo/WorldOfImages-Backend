using WorldOfImagesAPI_Model.ValueObjects;

namespace WorldOfImagesAPI_Model.DomainEntities
{
    public class Image
    {
        public string image { get; private set; }
        public Coordinates coordinates { get; private set; }


        public Image(int x, int y, string image)
        {
            coordinates = new Coordinates(x, y);
            this.image = image;
        }

    }
}
