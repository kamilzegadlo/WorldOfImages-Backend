using WorldOfImagesAPI.Controllers;
using WorldOfImagesAPI.ValueObjects;
using WorldOfImagesAPI.DomainEntities;
using Xunit;
using WorldOfImagesAPI.Repositories;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WorldOfImagesAPI.HttpRequestObjects;

namespace WorldOfImagesAPITest
{
    public class ImageControllerTests
    {
        private readonly IImageRepository _imageRepository;
        private readonly ImageController _imageController;

        public ImageControllerTests()
        {
            _imageRepository = A.Fake<IImageRepository>();
            _imageController = new ImageController(_imageRepository);
        }

        [Fact]
        public void Add_Image_ShouldCallImageRepository()
        {
            //arrange
            var addImageRequest = new AddImageRequest { x = 1, y = 2, image="unit test image" };

            var result = _imageController.Add(addImageRequest) as StatusCodeResult;

            //assert
            Assert.NotNull(result);
            Assert.Equal((int)HttpStatusCode.NoContent, result.StatusCode);
            A.CallTo(() => _imageRepository.AddImage(A<Image>.That.Matches(i =>
                i.coordinates.x == addImageRequest.x && i.coordinates.y == addImageRequest.y 
                && i.image == addImageRequest.image)))
                .MustHaveHappenedOnceExactly();
        }

    }
}
