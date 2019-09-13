using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APITest.Controllers;
using APITest.Models;
using APITest.Services;
using Moq;
using NUnit.Framework;

namespace AlbumMergeUnitTest
{
    [TestFixture]
    public class UnitTests
    {
        private PhotoAlbumController _photoAlbumController;
        private Mock<IPhotoAlbumService> _photoAlbumService;

        

        [SetUp]
        public void SetUp()
        {
            _photoAlbumService = new Mock<IPhotoAlbumService>();
            _photoAlbumController = new PhotoAlbumController(_photoAlbumService.Object);

        }

        [Test]
        public async Task WhenMergeIsCalledThenPhotoAlbumIsReturned()
        {
            var albums = new List<Album>()
            {
               new Album{Id =1,
                   Photos = new List<Photo>(){new Photo{AlbumId=1, Id = 1,ThumbnailUrl = "https://via.placeholder.com/150/92c952",Title = "accusamus beatae ad facilis cum similique qui sunt",Url = "https://via.placeholder.com/600/92c952" } },
                   UserId = 1,
                   Title = "non esse culpa molestiae omnis sed optio"

               }
            };
            _photoAlbumService.Setup(x => x.MergeAsync()).ReturnsAsync(albums);
            var result = await _photoAlbumController.MergeAsync();
            var albumResult = result.Any(x => x.Id == 1);
            Assert.IsTrue(albumResult);
        }
    }
}
