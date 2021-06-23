using Panda.ViewModels.Receipts;

namespace Panda.Services.Receipts
{
    public interface IReceiptsService
    {
        void Create(string packageId, string recepientId);

        AllReceiptsViewModel GetAllReceipts(string userId);
    }
}
