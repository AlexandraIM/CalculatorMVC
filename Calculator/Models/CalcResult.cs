using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Calculator.Models
{
    public class CalcResult
    {
        //id записи
        public int Id { get; set; }
        // первый аргумент
        [Required]
        [Display(Name ="First Argument")]
        public int arg1 { get; set; }
        // второй аргумент
        [Required]
        [Display(Name = "Second Argument")]
        public int arg2 { get; set; }
        // операция вычисления
        [Display(Name = "Operation")]
        public Operations operation { get; set; }
        // время операции
        
        public string operationTime { get; set; }
        // результат операции
        public int result { get; set; }
    }
}