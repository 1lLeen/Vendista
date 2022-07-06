using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectForVendista.Models.ModelsTerminals
{
    public class MultyCommandTerminal
    {
        public int command_id { get; set; }
        public int? parameter1 { get; set; } = 0;
        public int? parameter2 { get; set; } = 0;
        public int? parameter3 { get; set; } = 0;
        public int? parameter4 { get; set; } = 0;
        public string str_parameter1 { get; set; } = "string";
        public string str_parameter2 { get; set; } = "string";
    }
}