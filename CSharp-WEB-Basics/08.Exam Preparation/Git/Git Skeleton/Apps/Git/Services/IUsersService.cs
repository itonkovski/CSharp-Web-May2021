using Git.ViewModels.Users;

namespace Git.Services
{
    public interface IUsersService
    {
        void CreateUser(RegisterUserInputModel model);

        bool IsEmailAvailable(RegisterUserInputModel model);

        string GetUserId(LoginUserInputModel model);

        bool IsUsernameAvailable(RegisterUserInputModel model);
    }
}
