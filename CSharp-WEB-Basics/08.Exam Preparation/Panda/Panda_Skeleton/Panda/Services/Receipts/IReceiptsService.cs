using System.Linq;
using Panda.Data;
using Panda.ViewModels.Receipts;

namespace Panda.Services.Receipts
{
    public interface IReceiptsService
    {
        void CreateFromPackage(decimal weight, string packageId, string recipientId);

        IQueryable<Receipt> GetAll();
    }
}
