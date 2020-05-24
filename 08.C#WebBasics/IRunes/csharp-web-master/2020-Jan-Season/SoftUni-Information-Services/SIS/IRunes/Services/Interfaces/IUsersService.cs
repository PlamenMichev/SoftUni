using System;
using System.Collections.Generic;
using System.Text;

namespace IRunes.Services.Interfaces
{
    public interface IUsersService
    {
        void CreateUser(string username, string email, string password);

        string GetUserId(string username, string password);

        bool UsernameExists(string username);

        bool EmailExists(string email);

        string GetUserIdByEmail(string email, string password);

        string GetUsername(string id);
    }
}
