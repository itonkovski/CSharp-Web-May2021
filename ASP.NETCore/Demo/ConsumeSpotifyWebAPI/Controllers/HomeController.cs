using ConsumeSpotifyWebAPI.Models;
using ConsumeSpotifyWebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumeSpotifyWebAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISpotifyAccountService _spotifyAccountService;
        private readonly IConfiguration _configuration;
        private readonly ISpotifyService _spotifyService;

        public HomeController(
            ISpotifyAccountService spotifyAccountService,
            IConfiguration configuration,
            ISpotifyService spotifyService)
        {
            _spotifyAccountService = spotifyAccountService;
            _configuration = configuration;
            _spotifyService = spotifyService;
        }

        public async Task<IActionResult> Index()
        {
            var newReleases = await GetReleases();
            return View(newReleases);

            //var newArtists = await GetTracks();
            //return View(newArtists);

            //var newMusician = await GetMusician();
            //return View(newMusician);

            //var newTest = await GetSpotifyTest();
            //return View(newTest);
        }

        //private async Task<FullArtist> GetSpotifyTest()
        //{
        //    CredentialsAuth auth = new CredentialsAuth(_configuration["Spotify:ClientId"], _configuration["Spotify:ClientSecret"]);
        //    Token token = await auth.GetToken();
        //    _spotify = new SpotifyWebAPI()
        //    {
        //        AccessToken = token.AccessToken,
        //        TokenType = token.TokenType
        //    };
        //    FullArtist artist = _spotify.GetArtist("3EoonCWqWAoq6tfHvlSK4G");
        //    return artist;
        //}

        private async Task<IEnumerable<Release>> GetReleases()
        {
            try
            {
                var token = await _spotifyAccountService.GetToken(
                    _configuration["Spotify:ClientId"],
                    _configuration["Spotify:ClientSecret"]);

                var newReleases = await _spotifyService.GetNewReleases("NO", 20, token);

                return newReleases;
            }
            catch (Exception ex)
            {
                Debug.Write(ex);

                return Enumerable.Empty<Release>();
            }
        }

        //private async Task<IEnumerable<Artists>> GetTracks()
        //{
        //    try
        //    {
        //        var token = await _spotifyAccountService.GetToken(
        //            _configuration["Spotify:ClientId"],
        //            _configuration["Spotify:ClientSecret"]);

        //        var topTracks = await _spotifyService.GetTopTracks("3EoonCWqWAoq6tfHvlSK4G", "ES", token);

        //        return topTracks;
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.Write(ex);

        //        return Enumerable.Empty<Artists>();
        //    }
        //}

        //private async Task<IEnumerable<Musician>> GetMusician()
        //{
        //    //var token = await _spotifyAccountService.GetToken(
        //    //        _configuration["Spotify:ClientId"],
        //    //        _configuration["Spotify:ClientSecret"]);

        //    //var musician = await _spotifyService.GetMusician("3EoonCWqWAoq6tfHvlSK4G", token);

        //    //return musician;

        //    //Original working version
        //    try
        //    {
        //        var token = await _spotifyAccountService.GetToken(
        //            _configuration["Spotify:ClientId"],
        //            _configuration["Spotify:ClientSecret"]);

        //        var musicians = await _spotifyService.GetMusician("3EoonCWqWAoq6tfHvlSK4G,2CIMQHirSU0MQqyYHq0eOx", token);

        //        return musicians;
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.Write(ex);

        //        return Enumerable.Empty<Musician>();
        //    }
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
