using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectForVendista.Models.ModelsTable
{
    [Table("History")]
    public class History
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Command { get; set; }
        public string  Param1 { get; set; }
        public string  Param2 { get; set; }
        public string  Param3 { get; set; }
        public string  Status { get; set; }
   
    }
}