using ConsumeSpotifyWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsumeSpotifyWebAPI.Services
{
    public class SpotifyService : ISpotifyService
    {
        private readonly HttpClient _httpClient;

        public SpotifyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Musician>> GetMusician(string artistId, string accessToken)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await _httpClient.GetAsync($"artists?ids={artistId}");

            using var responseStream = await response.Content.ReadAsStreamAsync();
            var responseObject = await JsonSerializer.DeserializeAsync<GetArtist>(responseStream);

            return responseObject?.Artists?.Images.Select(i => new Musician
            {                
                //Name = i.Name,
                //Date = i.release_date,
                //ImageUrl = i.images.FirstOrDefault().url,
                //Link = i.ExternalUrls.Spotify,
                //Artists = string.Join(",", i.artists.Select(i => i.name))
            });

            //var returnItem = new Musician
            //{
            //    Name = responseObject.Name
            //};
            //return returnItem;

            //var returnItem = new Musician
            //{
            //    Name = responseObject.Name,
            //    Images = responseObject.Images.FirstOrDefault().Url,
            //    Link = responseObject.ExternalUrls.Spotify
            //};
            //return returnItem;
        }



        //public async Task<IEnumerable<Release>> GetNewReleases(string countryCode, int limit, string accessToken)
        //{
        //    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

        //    var response = await _httpClient.GetAsync($"browse/new-releases?country={countryCode}&limit={limit}");

        //    using var responseStream = await response.Content.ReadAsStreamAsync();
        //    var responseObject = await JsonSerializer.DeserializeAsync<GetNewReleaseResult>(responseStream);

        //    return responseObject?.albums?.items.Select(i => new Release
        //    {
        //        Name = i.name,
        //        Date = i.release_date,
        //        ImageUrl = i.images.FirstOrDefault().url,
        //        Link = i.external_urls.spotify,
        //        Artists = string.Join(",", i.artists.Select(i => i.name))
        //    });
        //}

        //public async Task<IEnumerable<Artists>> GetTopTracks(string artistId, string countryCode, string accessToken)
        //{
        //    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

        //    //var response = await _httpClient.GetAsync($"artists/{artistId}/albums?include_groups=single%2Cappears_on&market={countryCode}&limit={limit}");
        //    var response = await _httpClient.GetAsync($"artists/{artistId}/top-tracks?market={countryCode}");
        //    response.EnsureSuccessStatusCode();

        //    using var responseStream = await response.Content.ReadAsStreamAsync();
        //    var responseObject = await JsonSerializer.DeserializeAsync<GetArtistTopTracks>(responseStream);

        //    //return responseObject?.albums?.items.Select(i => new Release
        //    //{
        //    //    Name = i.name,
        //    //    Date = i.release_date,
        //    //    ImageUrl = i.images.FirstOrDefault().url,
        //    //    Link = i.external_urls.spotify,
        //    //    Artists = string.Join(",", i.artists.Select(i => i.name))
        //    //});

        //    return responseObject?.Tracks?.Select(i => new Artists
        //    {
        //        Tracks = string.Join(",", i.Name)
        //    });
        //}
    }
}
