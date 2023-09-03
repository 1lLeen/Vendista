
using ProjectForVendista.Models.Auth;
using ProjectForVendista.Models.ModelsTable;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;

namespace ProjectForVendista.Models.ModelsContext
{
    public class Context:DbContext
    {
        public Context()
            : base("name=Context") { }

        public DbSet<History> histories { get; set; }
        public DbSet<User> users { get; set; }
    }
}