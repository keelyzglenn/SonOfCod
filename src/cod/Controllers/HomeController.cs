using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using cod.Models;


namespace cod.Controllers
{
    public class HomeController : Controller
    {
        private SonOfCodSeafoodContext db = new SonOfCodSeafoodContext();
        public IActionResult Index()
        {
            return View(db.Subscribers.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Subscriber subscriber)
        {
            db.Subscribers.Add(subscriber);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }


}