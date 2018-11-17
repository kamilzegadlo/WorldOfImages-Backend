using WorldOfImagesAPI.DomainEntities;
using WorldOfImagesAPI.ValueObjects;

namespace WorldOfImagesAPI.Repositories
{
    public interface IPlaceRepository
    {
        Place GetPlace(Coordinates coordinates);
    }
}
