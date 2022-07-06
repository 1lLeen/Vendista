using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjectForVendista.Models.Auth.Context
{
    public class UserContext:DbContext
    {
        public UserContext()
            : base("name=Context") { }

        public DbSet<User> users { get; set; }
    }
}