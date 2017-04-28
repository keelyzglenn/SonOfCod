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
            MarketingPage marketingPage = db.MarketingPage.Single();
            return View(marketingPage);
        }
 

    }
}