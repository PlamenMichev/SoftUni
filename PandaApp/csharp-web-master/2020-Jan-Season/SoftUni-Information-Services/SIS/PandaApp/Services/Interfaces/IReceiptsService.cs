using PandaApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaApp.Services.Interfaces
{
    public interface IReceiptsService
    {
        ListRecieptsViewModel[] GetRecieptsForUser(string user);
    }
}
