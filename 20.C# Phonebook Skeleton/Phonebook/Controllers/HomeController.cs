using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Phonebook.Data;
using Phonebook.Data.Models;

namespace Phonebook.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = DataAccess.Contacts;
            return View(model);
        }
    }
}
