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
        public ActionResult Calculate(int arg1,Operations operation, int arg2)
        {
            try
            {
                int result = Result(arg1, arg2, operation);

                CalcResult calcResult = new CalcResult()
                {
                    arg1 = arg1,
                    arg2 = arg2,
                    operation = operation,
                    operationTime = DateTime.Now.ToString("HH:mm:ss"),
                    result = result
                };
                if (ModelState.IsValid)
                {
                    db.CalcResults.Add(calcResult);
                    db.SaveChanges();
                    ViewBag.Result = result;
                    ModelState.Clear();
                    return PartialView("_Result");
                }
            }catch(Exception ex)
            {
                ViewBag.Result = ex.Message;
                ModelState.Clear();
            }
            return View();
        }
        
        public ActionResult Log()
        {
            // получаем из бд все объекты Results
            IEnumerable<CalcResult> results = db.CalcResults.OrderByDescending(p => p.Id).Take(10);
            
            // передаем все объекты в динамическое свойство Results в ViewBag
            ViewBag.Results = results;
            // возвращаем представление
            return View();
        }

        private int Result(int argument1, int argument2, Operations operation)
        {
            switch (operation)
            {
                case Operations.Add: return argument1 + argument2;
                case Operations.Subtract: return argument1 - argument2;
                case Operations.Multiply: return argument1 * argument2;
                case Operations.Divide: return argument1 / argument2;
                default: return 0;

            }
        }
    }
}