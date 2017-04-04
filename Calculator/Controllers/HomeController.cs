using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Calculator.Models;
using System.Data.Entity;

namespace Calculator.Controllers
{
    public class HomeController : Controller
    {
        ClacResultContext db = new ClacResultContext();
        [HttpGet]
        public ActionResult Calculate()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Calculate(CalcResult result)
        {
            return View();
        }
        
    }
}