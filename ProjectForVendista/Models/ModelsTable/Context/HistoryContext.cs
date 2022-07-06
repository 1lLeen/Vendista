using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjectForVendista.Models.ModelsTable.Context
{
    public class HistoryContext:DbContext
    {
         public HistoryContext()
            : base("name=Context") { }
         public  DbSet<History> histories { get; set; }
    }
}