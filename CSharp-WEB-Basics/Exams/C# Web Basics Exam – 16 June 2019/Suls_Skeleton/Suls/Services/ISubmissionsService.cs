using System;
namespace Suls.Services
{
    public interface ISubmissionsService
    {
        void Create(string problemId, string userId, string code);
    }
}
