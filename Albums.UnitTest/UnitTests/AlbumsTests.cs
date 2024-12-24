using Albums.Business.Services;
using Albums.Domain.Entities;
using Albums.Infrastucture.Data.Repositories;
using Albums.Infrastucture.interfaces;
using FluentAssertions;
using Moq;

namespace Albums.Test.UnitTests
{
    public class AlbumTests
    {
        private readonly Mock<IAlbumsRepository> _albumsRepositoryMock;
        private readonly Mock<IPhotosRepository> _photosRepositoryMock;
        private readonly Mock<AlbumsDbRepository> _albumsDbRepositoryMock;
        private readonly AlbumsService _albumsService;

        public AlbumTests()
        {
            _albumsRepositoryMock = new Mock<IAlbumsRepository>();
            _photosRepositoryMock = new Mock<IPhotosRepository>();
            _albumsDbRepositoryMock = new Mock<AlbumsDbRepository>();

            _albumsService = new AlbumsService(_albumsRepositoryMock.Object, _photosRepositoryMock.Object, _albumsDbRepositoryMock.Object);
        }

        [Fact]
        public async Task Test_Albums_Filtered_By_Title()
        {
            // arrange
            string testTitle = "testTitle1";
            _albumsRepositoryMock.Setup(x => x.GetAlbumsAsync()).ReturnsAsync(new List<Album>() {
                new Album() { Id = 1, UserId = 123456, Title = "testTitle1" },
                new Album() { Id = 2, UserId = 865436, Title = "testTitle2" }
            });

            // act
            var result = await _albumsService.GetAlbumsFilteredByTitleAsync(testTitle);

            // assert
            result.Should().NotBeEmpty();
            result.Should().BeEquivalentTo(new List<Album>() { new Album() { Id = 1, UserId = 123456, Title = "testTitle1" } });
        }
    }
}