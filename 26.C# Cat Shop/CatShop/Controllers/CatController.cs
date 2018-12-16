using System;
using System.Linq;
using Microsoft.Azure.KeyVault.Models;

namespace CatShop.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using CatShop.Models;

    public class CatController : Controller
    {

        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            using (var db = new CatDbContext())
            {
                var model = db.Cats.ToList();
                return View(model);
            }
            
        }

        [HttpGet]
        [Route("create")]
        public ActionResult Create()
        {
             return View();          
        }

        [HttpPost]
        [Route("create")]
        public ActionResult Create(Cat cat)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            using (var db = new CatDbContext())
            {
                db.Cats.Add(cat);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            
        }

        [HttpGet]
        [Route("edit/{id}")]
        public ActionResult Edit(int id)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            using (var db = new CatDbContext())
            {
                Cat model = db.Cats.ToList().FirstOrDefault(x => x.Id == id);

                return View(model);
            }
        }

        [HttpPost]
        [Route("edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult EditConfirm(int id, Cat cat)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            using (var db = new CatDbContext())
            {
                Cat oldCat = db.Cats.ToList().FirstOrDefault(x => x.Id == id);

                oldCat.Name = cat.Name;
                oldCat.Nickname = cat.Nickname;
                oldCat.Price = cat.Price;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        [Route("delete/{id}")]
        public ActionResult Delete(int id)
        {
            using (var db = new CatDbContext())
            {
                Cat model = db.Cats.ToList().FirstOrDefault(x => x.Id == id);

                return View(model);
            }
        }

        [HttpPost]
        [Route("delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id, Cat catModel)
        {
            using (var db = new CatDbContext())
            {
                db.Cats.Remove(catModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        
    }
}
