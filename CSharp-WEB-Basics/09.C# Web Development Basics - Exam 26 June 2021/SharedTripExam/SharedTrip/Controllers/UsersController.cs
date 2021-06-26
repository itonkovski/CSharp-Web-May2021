using System;
using System.ComponentModel.DataAnnotations;
using SharedTrip.Models.Users;
using SharedTrip.Services.Users;
using SUS.HTTP;
using SUS.MvcFramework;

namespace SharedTrip.Controllers
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
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }
            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(LoginUserInputModel model)
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            var userId = this.usersService.GetUserId(model.Username, model.Password);
            if (userId == null)
            {
                return this.Error("Invalid username or password.");
            }
            this.SignIn(userId);
            return this.Redirect("/Trips/All");
        }

        public HttpResponse Register()
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }
            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterUserInputModel model)
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            if (string.IsNullOrEmpty(model.Username) ||
                model.Username.Length < 5 ||
                model.Username.Length > 20)
            {
                return this.Error("Username should be between 5 and 20 characters long.");
            }

            if (string.IsNullOrEmpty(model.Email) ||
                !new EmailAddressAttribute().IsValid(model.Email))
            {
                return this.Error("Invalid email address.");
            }

            if (string.IsNullOrEmpty(model.Password) ||
                model.Password.Length < 6 ||
                model.Password.Length > 20)
            {
                return this.Error("Password is required and should be between 6 and 20 characters long.");
            }

            if (model.ConfirmPassword != model.Password)
            {
                return this.Error("Passwords do not match.");
            }

            if (!this.usersService.IsEmailAvailable(model.Email))
            {
                return this.Error("The email address is already taken.");
            }

            if (!this.usersService.IsUsernameAvailable(model.Username))
            {
                return this.Error("The username is already taken.");
            }

            this.usersService.Create(model.Username, model.Email, model.Password);
            return this.Redirect("/Users/Login");
        }

        public HttpResponse Logout()
        {
            if (!this.IsUserSignedIn())
            {
                this.Redirect("/Users/Login");
            }

            this.SignOut();
            return this.Redirect("/");
        }
    }
}
