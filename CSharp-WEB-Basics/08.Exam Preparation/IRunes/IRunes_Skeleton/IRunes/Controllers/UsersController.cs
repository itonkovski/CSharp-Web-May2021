using System;
using System.ComponentModel.DataAnnotations;
using IRunes.Services.Users;
using IRunes.ViewModels.Users;
using SUS.HTTP;
using SUS.MvcFramework;

namespace IRunes.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public HttpResponse Login()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(LoginUserInputModel model)
        {
            var userId = this.usersService.GetUserId(model);

            if (userId == null)
            {
                return this.Error("Invalid username or password.");
            }
            this.SignIn(userId);

            return this.Redirect("/");
        }

        public HttpResponse Register()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterUserInputModel model)
        {
            if (string.IsNullOrEmpty(model.Username) ||
                model.Username.Length < 4 ||
                model.Username.Length > 10)
            {
                return this.Error("Name should be between 4 and 10 characters long.");
            }

            if (!this.usersService.IsUsernameAvailable(model))
            {
                return this.Error("Username not available.");
            }

            if (string.IsNullOrEmpty(model.Email)
                || !new EmailAddressAttribute().IsValid(model.Email))
            {
                return this.Error("Email is required.");
            }

            if (!this.usersService.IsEmailAvailable(model))
            {
                return this.Error("Email is not in the right format.");
            }

            if (string.IsNullOrEmpty(model.Password)
                || model.Password.Length < 6
                || model.Password.Length > 20)
            {
                return this.Error("Password should be between 6 and 20 characters long.");
            }

            if (model.ConfirmPassword != model.Password)
            {
                return this.Error("Passwords do not match.");
            }

            this.usersService.CreateUser(model);
            return this.Redirect("/Users/Login");
        }

        public HttpResponse Logout()
        {
            return this.Redirect("/");
        }
    }
}
