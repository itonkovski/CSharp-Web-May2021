using System;
using Suls.Services;
using Suls.ViewModels.Submissions;
using SUS.HTTP;
using SUS.MvcFramework;

namespace Suls.Controllers
{
    public class SubmissionsController : Controller
    {
        private readonly ISubmissionsService submissionsService;
        private readonly IProblemsService problemsService;

        public SubmissionsController(ISubmissionsService submissionsService, IProblemsService problemsService)
        {
            this.submissionsService = submissionsService;
            this.problemsService = problemsService;
        }

        public HttpResponse Create(string id)
        {
            var viewModel = new CreateViewModel
            {
                ProblemId = id,
                Name = this.problemsService.GetNameById(id)
            };
            return this.View(viewModel);
        }

        [HttpPost]
        public HttpResponse Create(string problemId, string code)
        {
            if (string.IsNullOrEmpty(code) ||
                code.Length < 30 ||
                code.Length > 800)
            {
                return this.Error("Code should be between 30 and 800 characteres long.");
            }
            var userId = this.GetUserId();
            this.submissionsService.Create(problemId, userId, code);
            return this.Redirect("/");
        }
    }
}
