using System;
using System.Linq;
using TestApplication.Data;

namespace TestApplication.Services.Dealers
{
    public class DealerService : IDealerService
    {
        private readonly ApplicationDbContext data;

        public DealerService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public bool IsDealer(string userId)
        {
            var dealer = this.data
                .Dealers
                .Any(x => x.UserId == userId);

            return dealer;
        }

        public int GetIdByUser(string userId)
        {
            var id = this.data
                .Dealers
                .Where(x => x.UserId == userId)
                .Select(x => x.Id)
                .FirstOrDefault();

            return id;
        }
    }
}
