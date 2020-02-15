using PandaApp.Services.Interfaces;
using PandaApp.ViewModels;
using SIS.HTTP;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaApp.Controllers
{
    public class ReceiptsController : Controller
    {
        private readonly IReceiptsService receiptsService;

        public ReceiptsController(IReceiptsService receiptsService)
        {
            this.receiptsService = receiptsService;
        }

        public HttpResponse Index()
        {
            ListRecieptsViewModel[] model = receiptsService.GetRecieptsForUser(this.User);

            return this.View(model);
        }
    }
}
