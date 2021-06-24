using System;
using System.Linq;
using Panda.Data;
using Panda.ViewModels.Receipts;

namespace Panda.Services.Receipts
{
    public class ReceiptsService : IReceiptsService
    {
        private readonly ApplicationDbContext dbContext;

        public ReceiptsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void CreateFromPackage(decimal weight, string packageId, string recipientId)
        {
            var receipt = new Receipt
            {
                PackageId = packageId,
                RecipientId = recipientId,
                Free = weight * 2.67M,
                IssuedOn = DateTime.UtcNow,
            };

            this.dbContext.Receipts.Add(receipt);
            this.dbContext.SaveChanges();
        }

        public IQueryable<Receipt> GetAll()
        {
            return this.dbContext.Receipts;
        }
    }
}
