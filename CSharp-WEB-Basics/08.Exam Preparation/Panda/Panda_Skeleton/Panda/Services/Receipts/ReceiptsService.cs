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

        public void Create(string packageId, string recepientId)
        {
            var package = this.dbContext.Packages
                .Find(packageId);

            var receipt = new Receipt
            {
                PackageId = packageId,
                RecipientId = recepientId,
                Free = package.Weight * 2.67m,
                IssuedOn = DateTime.UtcNow
            };

            this.dbContext.Receipts.Add(receipt);
            this.dbContext.SaveChanges();
                
        }

        public AllReceiptsViewModel GetAllReceipts(string userId)
        {
            var viewModel = new AllReceiptsViewModel
            {
                AllReceipts = this.dbContext.Receipts
                    .Where(x => x.RecipientId == userId)
                    .Select(x => new ReceiptViewModel
                    {
                        Id = x.Id,
                        Fee = x.Free,
                        IssuedOn = x.IssuedOn.ToString(),
                        RecepientName = x.Recipient.Username
                    })
                    .ToList()
            };
            return viewModel;
        }
    }
}
