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
            if (!IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            var userId = this.GetUserId();
            var viewModel = this.commitsService.GetAllCommits(userId);
            return this.View(viewModel);
        }

        public HttpResponse Create(string id)
        {
            if (!IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            var repositoryName = this.repositoriesService.GetRepoByName(id);

            var viewModel = new CreateCommitViewModel
            {
                Id = id,
                Name = repositoryName
            };
            return this.View(viewModel);
        }

        [HttpPost]
        public HttpResponse Create(string id, CreateCommitInputModel model)
        {
            if (!IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            if (string.IsNullOrEmpty(model.Description) ||
                model.Description.Length < 5)
            {
                return this.Error("Description is required and should be more than 5 characters long.");
            }

            var userId = this.GetUserId();
            this.commitsService.CreateCommit(userId, id, model);
            return this.Redirect("/Repositories/All");
        }

        public HttpResponse Delete(string id)
        {
            if (!IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            this.commitsService.DeleteCommit(id);

            return this.Redirect("/Commits/All");
        }
    }
}
