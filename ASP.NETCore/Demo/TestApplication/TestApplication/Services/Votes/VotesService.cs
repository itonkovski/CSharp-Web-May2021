using System;
using System.Linq;
using System.Threading.Tasks;
using TestApplication.Data;

namespace TestApplication.Services.Votes
{
    public class VotesService : IVotesService
    {
        private readonly ApplicationDbContext data;

        public VotesService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public double GetAverageVotes(string bikeId)
        {
            throw new NotImplementedException();
        }


        public Task SetVoteAsync(string bikeId, string userId, byte value)
        {
            throw new NotImplementedException();
        }
    }
}
