using System;
using Panda.Services.Receipts;
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
            var userId = this.GetUserId();

            var viewModel = this.receiptsService.GetAllReceipts(userId);
            return this.View(viewModel);
        }
    }
}
