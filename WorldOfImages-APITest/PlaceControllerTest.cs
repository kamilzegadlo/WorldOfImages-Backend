using WorldOfImagesAPI.Controllers;
using WorldOfImagesAPI.ValueObjects;
using WorldOfImagesAPI.DomainEntities;
using Xunit;
using WorldOfImagesAPI.Repositories;
using FakeItEasy;

namespace WorldOfImages_APITest
{
    public class PlaceControllerTest
    {
        private readonly IPlaceRepository _placeRepository;
        private readonly PlaceController _placeController;

        public PlaceControllerTest()
        {
            _placeRepository = A.Fake<IPlaceRepository>();

            _placeController = new PlaceController(_placeRepository);
        }

        [Fact]
        public void Get_Place_ShouldCallPlaceRepository()
        {
            //arrange
            var getPlaceRequest = new Coordinates(1, 2);
            var place = new Place(2, 3, "unit test name");
            A.CallTo(() => _placeRepository.GetPlace(getPlaceRequest)).Returns(place);

            //act
            var result = _placeController.Get(getPlaceRequest);

            //assert
            Assert.IsType(typeof(Place), result);
            Assert.Equal(2, result.x);
            Assert.Equal(3, result.y);
            Assert.Equal("unit test name", result.name);
            Assert.Equal(0, result.images.Count);
        }

    }
}
