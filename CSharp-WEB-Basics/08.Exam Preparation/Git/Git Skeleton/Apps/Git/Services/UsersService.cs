using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Git.Data;
using Git.ViewModels.Users;

namespace Git.Services
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext dbContext;

        public UsersService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void CreateUser(RegisterUserInputModel model)
        {
            var user = new User
            {
                Username = model.Username,
                Email = model.Email,
                Password = ComputeHash(model.Password)
            };
            this.dbContext.Users.Add(user);
            this.dbContext.SaveChanges();
        }

        public string GetUserId(LoginUserInputModel model)
        {
            var hashedPassword = ComputeHash(model.Password);
            var user = this.dbContext.Users
                .FirstOrDefault(x => x.Username == model.Username && x.Password == hashedPassword);

            return user?.Id;
        }

        public bool IsEmailAvailable(RegisterUserInputModel model)
        {
            return !this.dbContext.Users.Any(x => x.Email == model.Email);
        }

        public bool IsUsernameAvailable(RegisterUserInputModel model)
        {
            return !this.dbContext.Users.Any(x => x.Username == model.Username);
        }

        private string ComputeHash(string password)
        {
            var bytes = Encoding.UTF8.GetBytes(password);

            using (var hash = SHA512.Create())
            {
                var hashedInputBytes = hash.ComputeHash(bytes);
                var hashedInputStringBuilder = new StringBuilder(128);
                foreach (var b in hashedInputBytes)
                    hashedInputStringBuilder.Append(b.ToString("X2"));
                return hashedInputStringBuilder.ToString();
            }
        }
    }
}
