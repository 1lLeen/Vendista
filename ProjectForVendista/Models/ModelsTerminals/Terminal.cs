using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectForVendista.Models.ModelsTerminals
{
    public class Terminal
    {
        public int page_number { get; set; }
        public int items_per_page { get; set; }
        public int itmes_count { get; set; }
        public BodyTerminal[] items { get; set; }
    }



} 
