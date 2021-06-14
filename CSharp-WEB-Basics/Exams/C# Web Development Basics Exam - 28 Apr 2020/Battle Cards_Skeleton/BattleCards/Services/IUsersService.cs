using System;
namespace BattleCards.Services
{
    public interface IUsersService
    {
        string CreateUser(string username, string email, string password);

        bool IsUsernameAvailable(string username);

        bool IsEmailAvailable(string email);

        string GetUserId(string username, string password);
    }
}
