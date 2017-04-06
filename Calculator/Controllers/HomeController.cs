using Calculator.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

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
                //расчет результата
                int result = Result(arg1, arg2, operation);
                //создание екземпляра для базы данных
                CalcResult calcResult = new CalcResult()
                {
                    arg1 = arg1,
                    arg2 = arg2,
                    operation = operation,
                    operationTime = DateTime.Now.ToString("HH:mm:ss"),
                    result = result
                };
                //запись данных в базу
                if (ModelState.IsValid)
                {
                    db.CalcResults.Add(calcResult);
                    db.SaveChanges();
                    ViewBag.Result = result;
                    ModelState.Clear();
                    
                }
            }catch(Exception ex)
            {
                //ошибок
                ViewBag.Result = ex.Message;
                ModelState.Clear();
            }
            //вывод результата 
            return PartialView("_Result");
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
        //вспомогательный метод для расчета результата
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