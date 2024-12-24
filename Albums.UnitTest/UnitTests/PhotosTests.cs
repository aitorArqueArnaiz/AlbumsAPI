using Albums.Business.Services;
using Albums.Domain.Contracts;
using Albums.Domain.Entities;
using Albums.Infrastucture.interfaces;
using FluentAssertions;
using Moq;

namespace Albums.Test.UnitTests
{
    public class PhotosTests
    {
        private readonly Mock<IPhotosRepository> _photosRepositoryMock;
        private readonly Mock<IPhotosDbReposiory> _photosDbReposioryMock;
        private readonly IPhotosService _photosService;

        public PhotosTests()
        {
            _photosRepositoryMock = new Mock<IPhotosRepository>();
            _photosDbReposioryMock = new Mock<IPhotosDbReposiory>();

            _photosService = new PhotosService(_photosRepositoryMock.Object, _photosDbReposioryMock.Object);
        }

        [Fact]
        public async Task Test_Photos_Filtered_By_Title()
        {
            // arrange
            string testTitle = "testTitle1";
            _photosRepositoryMock.Setup(x => x.GetPhotosAsync()).ReturnsAsync(new List<Photo>() 
            {
                new Photo() { Id = 1, AlbumId = 123, Title = "testTitle1", Url = "testUrl1", ThumbnailUrl = "thumbnailTestUrl1" },
                new Photo() { Id = 2, AlbumId = 321, Title = "testTitle2", Url = "testUrl2", ThumbnailUrl = "thumbnailTestUrl2" }
            });

            // act
            var result = await _photosService.GetPhotosFilteredByTitleAsync(testTitle);

            // assert
            result.Should().NotBeEmpty();
            result.Should().BeEquivalentTo(new List<Photo>() { new Photo() { Id = 1, AlbumId = 123, Title = "testTitle1", Url = "testUrl1", ThumbnailUrl = "thumbnailTestUrl1" } });
        }

        [Fact]
        public async Task Test_Photos_Filtered_By_Album()
        {
            // arrange
            int testAlbum = 321;
            _photosRepositoryMock.Setup(x => x.GetPhotosAsync()).ReturnsAsync(new List<Photo>()
            {
                new Photo() { Id = 1, AlbumId = 123, Title = "testTitle1", Url = "testUrl1", ThumbnailUrl = "thumbnailTestUrl1" },
                new Photo() { Id = 2, AlbumId = 321, Title = "testTitle2", Url = "testUrl2", ThumbnailUrl = "thumbnailTestUrl2" }
            });

            // act
            var result = await _photosService.GetPhotosFilteredByAlbumAsync(testAlbum);

            // assert
            result.Should().NotBeEmpty();
            result.Should().BeEquivalentTo(new List<Photo>() { new Photo() { Id = 2, AlbumId = 321, Title = "testTitle2", Url = "testUrl2", ThumbnailUrl = "thumbnailTestUrl2" } });
        }
    }
}
