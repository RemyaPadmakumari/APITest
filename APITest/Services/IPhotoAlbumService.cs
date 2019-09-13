using System.Collections.Generic;
using System.Threading.Tasks;
using APITest.Models;

namespace APITest.Services
{
    public interface IPhotoAlbumService
    {
        Task<IEnumerable<Album>> MergeAsync();
    }
}