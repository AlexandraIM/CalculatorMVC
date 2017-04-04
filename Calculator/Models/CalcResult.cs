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
        public decimal arg1 { get; set; }
        // второй аргумент
        [Required]
        [Display(Name = "Second Argument")]
        public decimal arg2 { get; set; }
        // операция вычисления
        [Display(Name = "Operation")]
        public string operation { get; set; }
        // время операции
        [DataType(DataType.Time)]
        public DateTime operationTime { get; set; }
        // результат операции
        public decimal result { get; set; }
    }
}