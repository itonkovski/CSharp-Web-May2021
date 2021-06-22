using System;
using System.Linq;
using Git.Data;
using Git.ViewModels.Commits;

namespace Git.Services
{
    public class CommitsService : ICommitsService
    {
        private readonly ApplicationDbContext dbContext;

        public CommitsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void CreateCommit(string userId, string repositoryId, CreateCommitInputModel model)
        {
            var commit = new Commit
            {
                Description = model.Description,
                CreatedOn = DateTime.UtcNow,
                CreatorId = userId,
                RepositoryId = repositoryId
            };

            this.dbContext.Commits.Add(commit);
            this.dbContext.SaveChanges();
        }

        public void DeleteCommit(string id)
        {
            var commit = this.dbContext.Commits
                .Where(x => x.Id == id)
                .FirstOrDefault();
            this.dbContext.Remove(commit);
            this.dbContext.SaveChanges();

        }

        public AllCommitsViewModel GetAllCommits(string userId)
        {
            var viewModel = new AllCommitsViewModel
            {
                Commits = this.dbContext.Commits
                    .Where(x => x.CreatorId == userId)
                    .Select(x => new CommitViewModel
                    {
                        Id = x.Id,
                        Repository = x.Repository.Name,
                        Description = x.Description,
                        CreatedOn = x.CreatedOn.ToString()
                    })
                    .ToList()
            };
            return viewModel;
        }
    }
}
