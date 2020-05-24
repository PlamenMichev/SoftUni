using PandaApp.Models;
using PandaApp.Services.Interfaces;
using PandaApp.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace PandaApp.Services
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext db;

        public UsersService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void CreateUser(RegisterInputModel model)
        {
            User user = new User()
            {
                Id = Guid.NewGuid().ToString(),
                Email = model.Email,
                Username = model.Username,
                Password = this.Hash(model.Password)
            };

            this.db.Users.Add(user);
            this.db.SaveChanges();
        }

        public string GetUserId(string username, string password)
        {
            var passwordHash = this.Hash(password);
            return this.db.Users
                .Where(x => x.Username == username && x.Password == passwordHash)
                .Select(x => x.Id)
                .FirstOrDefault();
        }

        public string GetUserUsername(string userId)
        {
            return this.db.Users
                .First(x => x.Id == userId)
                .Username;
        }

        public bool IsEmailUsed(string email)
        {
            return this.db.Users.Any(x => x.Email == email);
        }

        public bool IsUsernameUsed(string username)
        {
            return this.db.Users.Any(x => x.Username == username);
        }

        public string[] GetAllUsersUsernames()
        {
            return this.db
                .Users
                .Select(x => x.Username)
                .ToArray();
        }

        public string GetIdWithUsername(string username)
        {
            return this.db
                .Users
                .Where(x => x.Username == username)
                .Select(x => x.Id)
                .First();
        }

        private string Hash(string input)
        {
            if (input == null)
            {
                return null;
            }

            var crypt = new SHA256Managed();
            var hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(input));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }

            return hash.ToString();
        }

        public User GetUserObject(string id)
        {
            return this.db.Users
                .FirstOrDefault(x => x.Id == id);
        }
    }
}
