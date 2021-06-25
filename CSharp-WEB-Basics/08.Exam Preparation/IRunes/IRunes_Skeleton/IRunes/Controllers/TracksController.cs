using System;
using IRunes.Data;
using IRunes.Services.Tracks;
using IRunes.ViewModels.Tracks;
using SUS.HTTP;
using SUS.MvcFramework;

namespace IRunes.Controllers
{
    public class TracksController : Controller
    {
        private readonly ITracksService tracksService;

        public TracksController(ITracksService tracksService)
        {
            this.tracksService = tracksService;
        }

        public HttpResponse Create(string albumId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var viewModel = new CreateTrackViewModel()
            {
                AlbumId = albumId
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public HttpResponse Create(CreateTrackInputModel model)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (model.Name.Length < 4 || model.Name.Length > 20)
            {
                return this.Error("Track name should be between 4 and 20characters.");
            }

            if (!model.Link.StartsWith("http"))
            {
                return this.Error("This is not valid link.");
            }

            if (model.Price < 0)
            {
                return this.Error("Price should be a positive number.");
            }

            this.tracksService.Create(model);
            return this.Redirect("/Albums/Details?id=" + model.AlbumId);
        }

        public HttpResponse Details(string trackId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var viewModel = this.tracksService.GetDetails(trackId);
            if (viewModel == null)
            {
                return this.Error("This track does not exist.");
            }

            return this.View(viewModel);
        }
    }
}
