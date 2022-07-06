using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectForVendista.Models.ModelsCommands
{
    public class BodyCommand
    {
        public int id { get; set; }
        public string name { get; set; }
        public string parameter_name1 { get; set; }
        public string parameter_name2 { get; set; }
        public string parameter_name3 { get; set; }
        public string parameter_name4 { get; set; }
        public string str_parameter_name1 { get; set; }
        public string str_parameter_name2 { get; set; }
        public int? parameter_default_value1{ get;set;}
        public int? parameter_default_value2 { get; set; }
        public int? parameter_default_value3 { get; set; }
        public int? parameter_default_value4 { get; set; }
        public string str_parameter_default_value1 { get; set; }
        public string str_parameter_default_value2 { get; set; }
        public bool visible { get; set; }
    }
}