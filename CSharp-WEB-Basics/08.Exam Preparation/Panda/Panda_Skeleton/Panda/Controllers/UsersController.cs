using System;
using System.ComponentModel.DataAnnotations;
using Panda.Services.Users;
using Panda.ViewModels.Users;
using SUS.HTTP;
using SUS.MvcFramework;

namespace Panda.Controllers
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
            if (IsUserSignedIn())
            {
                return this.Redirect("/");
            }
            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(LoginUserInputModel model)
        {
            if (IsUserSignedIn())
            {
                return this.Redirect("/");
            }

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
        public HttpResponse Register(CreateUserInputModel model)
        {
            if (IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            if (string.IsNullOrEmpty(model.Username) ||
                model.Username.Length < 5 ||
                model.Username.Length > 20)
            {
                return this.Error("Username is required and should be between 5 and 20 characters long.");
            }

            if (!this.usersService.IsUsernameAvailable(model))
            {
                return this.Error("Username is not available.");
            }

            if (string.IsNullOrEmpty(model.Email)
                || !new EmailAddressAttribute().IsValid(model.Email)
                || model.Email.Length < 5
                || model.Email.Length > 20)
            {
                return this.Error("Email is required and should be between 5 and 20 characters long.");
            }

            if (!this.usersService.IsEmailAvailable(model))
            {
                return this.Error("Email is not available.");
            }

            if (string.IsNullOrEmpty(model.Password))
            {
                return this.Error("Password is required.");
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
            if (this.IsUserSignedIn())
            {
                this.SignOut();
            }
            return this.Redirect("/");
        }
    }
}
