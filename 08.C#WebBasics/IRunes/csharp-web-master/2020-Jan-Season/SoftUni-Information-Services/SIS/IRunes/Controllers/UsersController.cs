using IRunes.Services.Interfaces;
using IRunes.ViewModels.Users;
using SIS.HTTP;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

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
        public HttpResponse Login(LoginInputModel model)
        {
            var user = this.usersService.GetUserId(model.Username, model.Password);
            var userWithEmail = this.usersService.GetUserIdByEmail(model.Username, model.Password);

            if (user == null && userWithEmail == null)
            {
                return this.View("Invalid credentials!");
            }

            string validId = string.Empty;
            if (user == null)
            {
                validId = userWithEmail;
            }
            else
            {
                validId = user;
            }

            this.SignIn(validId);
            return this.Redirect("/");
        }

        public HttpResponse Register()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterInputModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Email))
            {
                return this.Error("Email is invalid!");
            }

            if (model.Password.Length < 6 || model.Password.Length > 20)
            {
                return this.Error("Password must be between 6 and 20 characters!");
            }

            if (model.Username.Length < 4 || model.Username.Length > 10)
            {
                return this.Error("Password must be between 4 and 10 characters!");
            }

            if (this.usersService.EmailExists(model.Email))
            {
                return this.Error("Email is already used!");
            }

            if (this.usersService.UsernameExists(model.Username))
            {
                return this.Error("Username is already used!");
            }

            if (model.Password != model.ConfirmPassword)
            {
                return this.Error("Passwords should match!");
            }

            this.usersService.CreateUser(model.Username, model.Email, model.Password);
            return this.Redirect("/Users/Login");
        }

        public HttpResponse Logout()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            this.SignOut();
            return this.Redirect("/");
        }
    }
}
