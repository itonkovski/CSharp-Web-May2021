using System;
using System.Collections.Generic;
using Panda.ViewModels.Users;

namespace Panda.Services.Users
{
    public interface IUsersService
    {
        void CreateUser(CreateUserInputModel model);

        bool IsUsernameAvailable(CreateUserInputModel model);

        bool IsEmailAvailable(CreateUserInputModel model);

        string GetUserId(LoginUserInputModel model);

        string GetUsername(string id);

        string GetUserIdByUsername(string username);

        ICollection<string> GetAllUsernames();
    }
}

