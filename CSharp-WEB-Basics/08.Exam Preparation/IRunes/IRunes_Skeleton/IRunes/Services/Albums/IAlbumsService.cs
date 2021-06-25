using System;
using System.Collections.Generic;
using IRunes.ViewModels.Albums;

namespace IRunes.Services.Albums
{
    public interface IAlbumsService
    {
        void Create(CreateAlbumInputModel model);

        ICollection<AlbumViewModel> GetAll();

        AlbumDetailsViewModel GetDetails(string id);
    }
}
