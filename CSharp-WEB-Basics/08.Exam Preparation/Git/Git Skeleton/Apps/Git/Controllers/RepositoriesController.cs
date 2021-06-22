using System;
using Git.Services;
using Git.ViewModels.Repositories;
using SUS.HTTP;
using SUS.MvcFramework;

namespace Git.Controllers
{
    public class RepositoriesController : Controller
    {
        private readonly IRepositoriesService repositoriesService;

        public RepositoriesController(IRepositoriesService repositoriesService)
        {
            this.repositoriesService = repositoriesService;
        }

        public HttpResponse All()
        {
            var viewModel = this.repositoriesService.GetAllRepositories();
            return this.View(viewModel);
        }

        public HttpResponse Create()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(RepositoryInputModel model)
        {
            if (string.IsNullOrEmpty(model.Name) ||
                model.Name.Length < 3 ||
                model.Name.Length > 10)
            {
                return this.Error("Name should be between 3 and 10 characters long.");
            }

            var userId = GetUserId();
            this.repositoriesService.CreateRepository(userId, model);   

            return this.Redirect("/Repositories/All");
        }
    }
}
