using System;
using System.ComponentModel.DataAnnotations;
using CarShop.Services;
using CarShop.ViewModels.Users;
using SUS.HTTP;
using SUS.MvcFramework;

namespace CarShop.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public HttpResponse Login() => View();

        [HttpPost]
        public HttpResponse Login(LoginUserViewModel model)
        {
            var userId = this.usersService.GetUserId(model.Username, model.Password);
            if (userId == null)
            {
                return this.Error("Invalid username or password.");
            }
            this.SignIn(userId);
            return this.Redirect("/Cars/All");
        }

        public HttpResponse Register() => View();

        [HttpPost]
        public HttpResponse Register(RegisterUserViewModel model)
        {
            if (string.IsNullOrEmpty(model.Username) ||
                model.Username.Length < 4 ||
                model.Username.Length > 20)
            {
                return this.Error("Username should be between 4 and 20 characters long.");
            }

            if (!this.usersService.IsUsernameAvailable(model.Username))
            {
                return this.Error("Username unavailable.");
            }

            if (string.IsNullOrEmpty(model.Email) || !new EmailAddressAttribute().IsValid(model.Email))
            {
                return this.Error("Invalid email.");
            }

            if (string.IsNullOrEmpty(model.Password) ||
                model.Password.Length < 5 ||
                model.Password.Length > 20)
            {
                return this.Error("Password is required and should be between 5 and 20 characters long.");
            }

            if (model.ConfirmPassword != model.Password)
            {
                return this.Error("Paswords do not macth.");
            }

            if (model.UserType != "Mechanic" && model.UserType != "Client")
            {
                return this.Error("User should be either a mechanic or a client.");
            }

            this.usersService.Create(model.Username, model.Email, model.Password, model.UserType);
            return this.Redirect("/Users/Login");
        }

        public HttpResponse Logout()
        {
            this.SignOut();
            return this.Redirect("/");
        }
    }
}
