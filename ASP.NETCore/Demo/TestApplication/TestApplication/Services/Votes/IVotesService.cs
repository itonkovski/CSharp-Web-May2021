using System;
using System.Threading.Tasks;

namespace TestApplication.Services.Votes
{
    public interface IVotesService
    {
        Task SetVoteAsync(string bikeId, string userId, byte value);

        double GetAverageVotes(string bikeId);
    }
}
