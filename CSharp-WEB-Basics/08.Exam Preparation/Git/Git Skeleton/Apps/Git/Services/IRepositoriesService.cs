using System;
using Git.ViewModels.Repositories;

namespace Git.Services
{
    public interface IRepositoriesService
    {
        public void CreateRepository(string userId, RepositoryInputModel model);

        AllRepositoriesViewModel GetAllRepositories();

        string GetRepoByName(string id);
    }
}
