using WorldOfImages_API.Controllers;
using WorldOfImagesAPI.ValueObjects;
using Xunit;

namespace WorldOfImages_APITest
{
    public class PlaceControllerTest
    {
        private readonly PlaceController placeController = new PlaceController();

        [Fact]
        public void Get_Place_ShouldReturnFixedValue()
        {
            //arrange
            var getPlaceRequest = new GetPlaceRequest(1, 2);

            //act
            var result = placeController.Get(getPlaceRequest);

            //assert
            Assert.Equal("fixedPlace", result);
        }

    }
}
