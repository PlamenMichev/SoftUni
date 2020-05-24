using PandaApp.Services.Interfaces;
using PandaApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PandaApp.Services
{
    public class ReceiptsService : IReceiptsService
    {
        private readonly ApplicationDbContext db;
        private readonly IUsersService usersService;

        public ReceiptsService(ApplicationDbContext db, IUsersService usersService)
        {
            this.db = db;
            this.usersService = usersService;
        }

        public ListRecieptsViewModel[] GetRecieptsForUser(string user)
        {
            return this.db
                .Receipts
                .Where(x => x.RecipientId == user)
                .Select(x => new ListRecieptsViewModel
                {
                    Id = x.Id,
                    IssuedOn = x.IssuedOn,
                    Fee = x.Fee,
                    RecipientName = this.usersService.GetUserObject(user).Username,
                })
                .ToArray();
        }
    }
}
