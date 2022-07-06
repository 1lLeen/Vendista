using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectForVendista.Models.ModelsCommands
{
   
    public class Command
    {
        public int pageNumber { get; set; }
        public int itemsPerPage { get; set; }
        public int itemsCount { get; set; }
        public BodyCommand[] items { get; set; }

    }
}