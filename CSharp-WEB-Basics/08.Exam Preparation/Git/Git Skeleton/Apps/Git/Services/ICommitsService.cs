using System;
using Git.ViewModels.Commits;

namespace Git.Services
{
    public interface ICommitsService
    {
        public void CreateCommit(string userId, string repositoryId, CreateCommitInputModel model);
    }
}
