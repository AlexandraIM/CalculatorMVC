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
            try
            {
                decimal result = Result(arg1, arg2, operation);

                CalcResult calcResult = new CalcResult()
                {
                    arg1 = arg1,
                    arg2 = arg2,
                    operation = operation,
                    operationTime = DateTime.Now.TimeOfDay,
                    result = result
                };
                if (ModelState.IsValid)
                {
                    db.CalcResults.Add(calcResult);
                    db.SaveChanges();
                    ViewBag.Result = result;
                    ModelState.Clear();
                    return View();
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
            IEnumerable<CalcResult> results = db.CalcResults;
            // передаем все объекты в динамическое свойство Results в ViewBag
            ViewBag.Results = results;
            // возвращаем представление
            return View();
        }

        private decimal Result(decimal argument1, decimal argument2, string operation)
        {
            switch (operation)
            {
                case "addition": return argument1 + argument2; 
                case "subtraction": return argument1 - argument2;
                case "multiplication": return argument1 * argument2;
                case "division": return argument1 / argument2; 
                default: return 0;
                   
            }
        }
    }
}