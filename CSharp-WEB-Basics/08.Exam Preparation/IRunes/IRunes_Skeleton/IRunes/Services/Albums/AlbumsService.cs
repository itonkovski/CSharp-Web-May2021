using System;
using System.Collections.Generic;
using System.Linq;
using IRunes.Data;
using IRunes.ViewModels.Albums;
using IRunes.ViewModels.Tracks;

namespace IRunes.Services.Albums
{
    public class AlbumsService : IAlbumsService
    {
        private readonly ApplicationDbContext dbContext;

        public AlbumsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(CreateAlbumInputModel model)
        {
            var album = new Album
            {
                Name = model.Name,
                Cover = model.Cover,
                Price = 0M
            };

            this.dbContext.Albums.Add(album);
            this.dbContext.SaveChanges();
        }

        public ICollection<AlbumViewModel> GetAll()
        {
            var albumsCollection = this.dbContext.Albums
                .Select(x => new AlbumViewModel
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToList();

            return albumsCollection;
        }

        public AlbumDetailsViewModel GetDetails(string id)
        {
            var album = this.dbContext.Albums
                .Where(x => x.Id == id)
                .Select(x => new AlbumDetailsViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Cover = x.Cover,
                    Price = x.Price,
                    Tracks = x.Tracks.Select(y => new TrackInfoViewModel()
                    {
                        Id = y.Id,
                        Name = y.Name

                    }).ToList()
                })
                .FirstOrDefault();

            return album;
        }
    }
}
