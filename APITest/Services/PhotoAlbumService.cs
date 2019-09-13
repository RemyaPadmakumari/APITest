using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using APITest.Models;

namespace APITest.Services
{
    public class PhotoAlbumService : IPhotoAlbumService
    {
        private readonly HttpClient _client;

        public PhotoAlbumService()
        {
            _client = new HttpClient() { BaseAddress = new Uri("http://jsonplaceholder.typicode.com") };
        }
        
        public async Task<IEnumerable<Album>> MergeAsync()
        {
            var albumsResponse = await _client.GetAsync("/albums");
            if (!albumsResponse.IsSuccessStatusCode)
                throw new Exception($"Failed to load Albums. Error: {await albumsResponse.Content.ReadAsStringAsync()}");

            var albums = await albumsResponse.Content.ReadAsAsync<List<Album>>();

            var photosResponse = await _client.GetAsync("/photos");
            if (!photosResponse.IsSuccessStatusCode)
                throw new Exception($"Failed to load Photos. Error: {await photosResponse.Content.ReadAsStringAsync()}");

            var photos = await photosResponse.Content.ReadAsAsync<List<Photo>>();

            foreach (var album in albums)
            {
                album.Photos = photos.Where(x => x.AlbumId == album.Id);
            }

            return albums;
        }
    }
}