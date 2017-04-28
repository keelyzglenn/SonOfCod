using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using cod.Models;


namespace cod.Controllers
{
    public class PostController : Controller
    {
        private SonOfCodSeafoodContext db = new SonOfCodSeafoodContext();
        public IActionResult Index()
        {
            return View(db.Posts.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Post post)
        {
            db.Posts.Add(post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }


}