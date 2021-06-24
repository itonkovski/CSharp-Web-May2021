using System;
using System.Linq;
using Panda.Data.Enums;
using Panda.Services.Packages;
using Panda.Services.Users;
using Panda.ViewModels.Packages;
using SUS.HTTP;
using SUS.MvcFramework;

namespace Panda.Controllers
{
    public class PackagesController : Controller
    {
        private readonly IPackagesService packagesService;
        private readonly IUsersService usersService;

        public PackagesController(IPackagesService packagesService, IUsersService usersService)
        {
            this.packagesService = packagesService;
            this.usersService = usersService;
        }

        public HttpResponse Create()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            var viewModel = this.usersService.GetAllUsernames();
            return this.View(viewModel);
        }

        [HttpPost]
        public HttpResponse Create(CreatePackageInputModel model)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrEmpty(model.Description) ||
                model.Description.Length < 5 ||
                model.Description.Length > 20)
            {

                return this.Redirect("/Packages/Create");
            }

            this.packagesService.Create(model.Description, model.Weight, model.ShippingAddress, model.RecipientName);
            return this.Redirect("/Packages/Pending");
        }

        public HttpResponse Deliver(string id)
        {
            this.packagesService.Deliver(id);
            return this.Redirect("/Packages/Delivered");
        }

        public HttpResponse Delivered()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var packages = this.packagesService.GetAllByStatus(PackageStatus.Delivered)
                .Select(x => new PackageViewModel
                {
                    Description = x.Description,
                    Id = x.Id,
                    Weight = x.Weight,
                    ShippingAddress = x.ShippingAddress,
                    RecipientName = x.Recipient.Username,
                }).ToList();
            return this.View(new AllPackagesViewModel { Packages = packages });
        }

        public HttpResponse Pending()
        {
            var packages = this.packagesService.GetAllByStatus(PackageStatus.Pending)
                .Select(x => new PackageViewModel
                {
                    Description = x.Description,
                    Id = x.Id,
                    Weight = x.Weight,
                    ShippingAddress = x.ShippingAddress,
                    RecipientName = x.Recipient.Username,
                }).ToList();
            return this.View(new AllPackagesViewModel { Packages = packages });
        }
    }
}
