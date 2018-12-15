using WorldOfImagesAPI.HttpRequestObjects;
using WorldOfImagesAPI.ValueObjects;

namespace WorldOfImagesAPI.DomainEntities
{
    public class Image
    {
        public string image { get; private set; }
        public Coordinates coordinates { get; private set; }


        public Image(AddImageRequest addImageRequest)
        {
            coordinates = new Coordinates(addImageRequest.x, addImageRequest.y);
            image = addImageRequest.image;
        }

    }
}
