using System;
using System.Linq;
using Panda.Services.Receipts;
using Panda.ViewModels.Receipts;
using SUS.HTTP;
using SUS.MvcFramework;

namespace Panda.Controllers
{
    public class ReceiptsController : Controller
    {
        private readonly IReceiptsService receiptsService;

        public ReceiptsController(IReceiptsService receiptsService)
        {
            this.receiptsService = receiptsService;
        }

        public HttpResponse Index()
        {
            {
                var viewModel = this.receiptsService
                    .GetAll()
                    .Select(
                    x => new ReceiptViewModel
                    {
                        Id = x.Id,
                        Fee = x.Free,
                        IssuedOn = x.IssuedOn,
                        //RecipientName = x.Recipient.Username,
                    }).ToList();

                return this.View(viewModel);
            }
        }
    }
}
