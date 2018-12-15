using WorldOfImagesAPI_Model.DomainEntities;

namespace WorldOfImagesAPI_Model.Repositories
{
    public interface IImageRepository
    {
        void AddImage(Image image);
    }
}
