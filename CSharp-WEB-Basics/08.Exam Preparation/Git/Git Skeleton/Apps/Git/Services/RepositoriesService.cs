using System;
using System.Linq;
using Git.Data;
using Git.ViewModels.Repositories;

namespace Git.Services
{
    public class RepositoriesService : IRepositoriesService
    {
        private readonly ApplicationDbContext dbContext;

        public RepositoriesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void CreateRepository(string userId, RepositoryInputModel model)
        {
            var repository = new Repository
            {
                Name = model.Name,
                OwnerId = userId,
                CreatedOn = DateTime.UtcNow,
                IsPublic = model.RepositoryType == "Public" ? true : false
            };

            this.dbContext.Repositories.Add(repository);
            this.dbContext.SaveChanges();
        }

        public AllRepositoriesViewModel GetAllRepositories()
        {
            var viewModel = new AllRepositoriesViewModel
            {
                AllRepositoryViewModels = this.dbContext.Repositories
                    .Where(x => x.IsPublic == true)
                    .Select(x => new RepositoryViewModel
                    {
                        Id = x.Id,
                        RepositoryName = x.Name,
                        OwnerName = x.Owner.Username,
                        CreatedOn = x.CreatedOn.ToString(),
                        Commits = x.Commits.Count()
                    })
                        .ToList()
            };
            return viewModel;
        }
    }
}
