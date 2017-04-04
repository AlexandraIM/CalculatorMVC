using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Calculator.Models
{
    public class ClacResultContext: DbContext
    {
        public DbSet<CalcResult> CalcResults { get; set; }
    }
}