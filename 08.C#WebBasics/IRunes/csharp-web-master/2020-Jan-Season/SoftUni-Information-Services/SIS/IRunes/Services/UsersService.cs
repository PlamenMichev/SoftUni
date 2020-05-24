using IRunes.Models;
using IRunes.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace IRunes.Services
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext db;

        public UsersService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void CreateUser(string username, string email, string password)
        {
            User user = new User
            {
                Username = username,
                Email = email,
                Password = this.Hash(password),
            };

            this.db.Users.Add(user);
            this.db.SaveChanges();
        }

        public bool EmailExists(string email)
        {
            return this.db
                .Users
                .Any(x => x.Email == email);
        }

        public string GetUserId(string username, string password)
        {
            return this.db
                .Users
                .Where(x => x.Username == username && this.Hash(password) == x.Password)
                .Select(x => x.Id)
                .FirstOrDefault();
        }

        public string GetUserIdByEmail(string email, string password)
        {
            return this.db
                .Users
                .Where(x => x.Email == email && this.Hash(password) == x.Password)
                .Select(x => x.Id)
                .FirstOrDefault();
        }

        public string GetUsername(string id)
        {
            return this.db.Users
                .Where(x => x.Id == id)
                .Select(x => x.Username)
                .FirstOrDefault();
        }

        public bool UsernameExists(string username)
        {

            return this.db
                .Users
                .Any(x => x.Username == username);
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
    }
}
