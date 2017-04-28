using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using cod.Models;


namespace cod.Controllers
{
    public class MarketingPageController : Controller
    {

        private SonOfCodSeafoodContext db = new SonOfCodSeafoodContext();
        public IActionResult Index()
        {
            return View(db.MarketingPage.ToList());
        }

        public IActionResult Details(int id)
        {
            var thisMarketingPage = db.MarketingPage.Include(marketingPages => marketingPages.Posts).FirstOrDefault(marketingPages => marketingPages.Id == id);
            return View(thisMarketingPage);
        }

        public IActionResult Create()
        {
            return View();
        }



        public IActionResult Edit(int id)
        {
            var thisMarketingPage = db.MarketingPage.FirstOrDefault(marketingPages => marketingPages.Id == id);
            return View(thisMarketingPage);
        }

        [HttpPost]
        public IActionResult Edit(MarketingPage marketingpage)
        {
            db.Entry(marketingpage).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}