using System;
using System.Linq;
using IRunes.Data;
using IRunes.ViewModels.Tracks;

namespace IRunes.Services.Tracks
{
    public class TracksService : ITracksService
    {
        private readonly ApplicationDbContext dbContext;

        public TracksService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(CreateTrackInputModel model)
        {
            var track = new Track
            {
                AlbumId = model.AlbumId,
                Name = model.Name,
                Link = model.Link,
                Price = model.Price
            };

            this.dbContext.Tracks.Add(track);
            var allTrackPricesSum = this.dbContext.Tracks
                .Where(x => x.AlbumId == model.AlbumId)
                .Sum(x => x.Price) + model.Price;
            var album = this.dbContext.Albums.Find(model.AlbumId);
            album.Price = allTrackPricesSum * 0.87M;

            this.dbContext.SaveChanges();
        }

        public TrackDetailsViewModel GetDetails(string trackId)
        {
            var track = this.dbContext.Tracks
                .Where(x => x.Id == trackId)
                .Select(x => new TrackDetailsViewModel
                {
                    AlbumId = x.AlbumId,
                    Name = x.Name,
                    Link = x.Link,
                    Price = x.Price
                })
                .FirstOrDefault();

            return track;
        }
    }
}
