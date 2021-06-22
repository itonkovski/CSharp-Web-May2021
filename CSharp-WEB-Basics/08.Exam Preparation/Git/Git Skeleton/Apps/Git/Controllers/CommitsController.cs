using System;
using Git.Services;
using Git.ViewModels.Commits;
using SUS.HTTP;
using SUS.MvcFramework;

namespace Git.Controllers
{
    public class CommitsController : Controller
    {
        private readonly ICommitsService commitsService;
        private readonly IRepositoriesService repositoriesService;

        public CommitsController(ICommitsService commitsService, IRepositoriesService repositoriesService)
        {
            this.commitsService = commitsService;
            this.repositoriesService = repositoriesService;
        }

        public HttpResponse All()
        {
            return this.View();
        }

        public HttpResponse Create()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(string repId, CreateCommitInputModel model)
        {
            if (string.IsNullOrEmpty(model.Description) ||
                model.Description.Length < 5)
            {
                return this.Error("Description is required and should be more than 5 characters long.");
            }

            var userId = this.GetUserId();
            this.commitsService.CreateCommit(userId, repId, model);
            return this.Redirect("/Repositories/All");
        }
    }
}
