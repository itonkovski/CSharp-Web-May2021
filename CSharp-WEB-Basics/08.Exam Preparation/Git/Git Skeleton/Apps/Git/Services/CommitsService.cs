using System;
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
    }
}
