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
        //создаем контекст данных
        ClacResultContext db = new ClacResultContext();
        //представление калькулятора
        [HttpGet]
        public ActionResult Calculate()
        {
            return View();
        }
        //обработка результата калькулятора и сохранение в базу логирования
        [HttpPost]
        public ActionResult Calculate(decimal arg1, string operation, decimal arg2)
        {
            CalcResult result = new CalcResult() {
                arg1 = arg1,
                arg2 = arg2,
                operation = operation,
                operationTime = DateTime.Now.TimeOfDay,
                result = arg1 + arg2

            };
            if (ModelState.IsValid)
            {
                db.CalcResults.Add(result);
                db.SaveChanges();
            }

            return View();
        }
        
        public ActionResult Log()
        {
            // получаем из бд все объекты Results
            IEnumerable<CalcResult> results = db.CalcResults;
            // передаем все объекты в динамическое свойство Results в ViewBag
            ViewBag.Results = results;
            // возвращаем представление
            return View();
        }
    }
}