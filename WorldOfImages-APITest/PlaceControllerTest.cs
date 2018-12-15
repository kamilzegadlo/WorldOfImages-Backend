using WorldOfImagesAPI.Controllers;
using WorldOfImagesAPI.ValueObjects;
using WorldOfImagesAPI.DomainEntities;
using Xunit;
using WorldOfImagesAPI.Repositories;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WorldOfImagesAPI.HttpRequestObjects;

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
            var getPlaceRequest = new GetPlaceRequest { x = 1, y = 2 };
            var place = new Place(2, 3, "unit test name");
            A.CallTo(() => _placeRepository.GetPlace(A<Coordinates>.That.Matches((c)=>c.x==1 && c.y==2)))
                .Returns(place);

            //act
            var result = _placeController.Get(getPlaceRequest) as OkObjectResult;

            //assert
            Assert.NotNull(result);
            Assert.IsType(typeof(Place), result.Value);
            var resultPlace = result.Value as Place;
            Assert.Equal(2, resultPlace.coordinates.x);
            Assert.Equal(3, resultPlace.coordinates.y);
            Assert.Equal("unit test name", resultPlace.name);
            Assert.Equal(0, resultPlace.images.Count);
        }

        [Fact]
        public void Get_Place_IfPlaceNotDefinedYet()
        {
            //arrange
            var getPlaceRequest = new GetPlaceRequest { x=1, y=2};
            A.CallTo(() => _placeRepository.GetPlace(A<Coordinates>.That.Matches((c)=>c.x==1&&c.y==2)))
                .Returns(null);

            //act
            var result = _placeController.Get(getPlaceRequest) as StatusCodeResult;

            //assert
            Assert.NotNull(result);
            Assert.Equal((int)HttpStatusCode.NotFound, result.StatusCode);
        }

        [Fact]
        public void Get_Place_IfRequestInvalid()
        {
            //arrange
            var getPlaceRequest = new GetPlaceRequest { x = 1, y = 2 };
            _placeController.ModelState.AddModelError("unit test", "unit test");

            //act
            var result = _placeController.Get(getPlaceRequest) as BadRequestObjectResult;

            //assert
            Assert.NotNull(result);
            Assert.Equal((int)HttpStatusCode.BadRequest, result.StatusCode);
            Assert.NotNull(result.Value);
        }

        [Fact]
        public void Add_Place_ShouldCallPlaceRepository()
        {
            //arrange
            var place = new AddPlaceRequest { x = 1, y = 2, name = "unit test name" };

            //act
            var result = _placeController.Add(place) as StatusCodeResult;

            //assert
            Assert.NotNull(result);
            Assert.Equal((int)HttpStatusCode.NoContent, result.StatusCode);
            A.CallTo(() => _placeRepository.AddPlace(A<Place>.That.Matches(p=>
                p.coordinates.x==place.x && p.coordinates.y==place.y && p.name==place.name)))
                .MustHaveHappenedOnceExactly();
        }

        [Fact]
        public void Add_Place_IfRequestInvalid()
        {
            //arrange
            var place = new AddPlaceRequest { x = 1, y = 2, name = "unit test name" };
            _placeController.ModelState.AddModelError("unit test key", "unit test value");

            //act
            var result = _placeController.Add(place) as BadRequestObjectResult;

            //assert
            Assert.NotNull(result);
            Assert.Equal((int)HttpStatusCode.BadRequest, result.StatusCode);
            Assert.NotNull(result.Value);
        }

    }
}
