using PandaApp.Models;
using PandaApp.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaApp.Services.Interfaces
{
    public interface IUsersService
    {
        string GetUserId(string username, string password);

        void CreateUser(RegisterInputModel model);
        
        bool IsUsernameUsed(string username);

        bool IsEmailUsed(string email);

        string GetUserUsername(string userId);

        string[] GetAllUsersUsernames();

        string GetIdWithUsername(string username);

        User GetUserObject(string id);
    }
}
