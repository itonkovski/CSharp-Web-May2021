using System;
using IRunes.ViewModels.Users;

namespace IRunes.Services.Users
{
    public interface IUsersService
    {
        void CreateUser(RegisterUserInputModel model);

        bool IsEmailAvailable(RegisterUserInputModel model);

        string GetUserId(LoginUserInputModel model);

        bool IsUsernameAvailable(RegisterUserInputModel model);

        string GetUsername(string userId);
    }
}
