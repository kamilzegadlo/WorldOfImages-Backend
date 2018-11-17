using WorldOfImagesAPI.Controllers;
using WorldOfImagesAPI.ValueObjects;
using WorldOfImagesAPI.DomainEntities;
using Xunit;
using WorldOfImagesAPI.Repositories;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
            var result = _placeController.Get(getPlaceRequest) as OkObjectResult;

            //assert
            Assert.NotNull(result);
            Assert.IsType(typeof(Place), result.Value);
            var resultPlace = result.Value as Place;
            Assert.Equal(2, resultPlace.x);
            Assert.Equal(3, resultPlace.y);
            Assert.Equal("unit test name", resultPlace.name);
            Assert.Equal(0, resultPlace.images.Count);
        }

        [Fact]
        public void Get_Place_IfPlaceNotDefinedYet()
        {
            //arrange
            var getPlaceRequest = new Coordinates(1, 2);
            A.CallTo(() => _placeRepository.GetPlace(getPlaceRequest)).Returns(null);

            //act
            var result = _placeController.Get(getPlaceRequest) as StatusCodeResult;

            //assert
            Assert.NotNull(result);
            Assert.Equal((int)HttpStatusCode.NotFound, result.StatusCode);
        }

        [Fact]
        public void Add_Place()
        {
            //arrange
            var place = new Place(1, 2, "unit test name");;

            //act
            var result = _placeController.Add(place) as StatusCodeResult;

            //assert
            Assert.NotNull(result);
            Assert.Equal((int)HttpStatusCode.NoContent, result.StatusCode);
        }

    }
}
