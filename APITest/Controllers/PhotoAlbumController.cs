using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using APITest.Models;
using APITest.Services;

namespace APITest.Controllers
{
    public class PhotoAlbumController : ApiController
    {
        private readonly IPhotoAlbumService _photoAlbumService;

        public PhotoAlbumController()
        {
            _photoAlbumService = new PhotoAlbumService();
        }

        public PhotoAlbumController(IPhotoAlbumService photoAlbumService)
        {
            _photoAlbumService = photoAlbumService ?? new PhotoAlbumService();
        }

        // GET api/PhotoAlbum ----- use this uri to get the merged AlbumPhotos
        [HttpGet]
        public async Task<IEnumerable<Album>> MergeAsync()
        {
            var photoAlbums = await _photoAlbumService.MergeAsync();

            return photoAlbums ?? new List<Album>();
        }
    }
}
