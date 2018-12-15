using WorldOfImagesAPI_Model.DomainEntities;
using WorldOfImagesAPI_Model.ValueObjects;

namespace WorldOfImagesAPI_Model.Repositories
{
    public interface IPlaceRepository
    {
        Place GetPlace(Coordinates coordinates);

        void AddPlace(Place place);
    }
}
