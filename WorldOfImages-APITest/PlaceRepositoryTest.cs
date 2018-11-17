using WorldOfImagesAPI.Controllers;
using WorldOfImagesAPI.ValueObjects;
using WorldOfImagesAPI.DomainEntities;
using WorldOfImagesAPI.Repositories;
using Xunit;

namespace WorldOfImagesAPITest
{
    public class PlaceRepositoryTest
    {
        [Fact]
        public void GetPlace()
        {
            var placeRepository = new PlaceRepository();
            var result = placeRepository.GetPlace(new Coordinates(1, 2));

            Assert.Equal(null, result);

        }
    }
}
