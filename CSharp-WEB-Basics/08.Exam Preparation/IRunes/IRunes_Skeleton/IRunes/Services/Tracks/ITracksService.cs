using System;
using IRunes.ViewModels.Tracks;

namespace IRunes.Services.Tracks
{
    public interface ITracksService
    {
        void Create(CreateTrackInputModel model);

        TrackDetailsViewModel GetDetails(string trackId);
    }
}
