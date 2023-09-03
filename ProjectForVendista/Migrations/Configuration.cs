namespace ProjectForVendista.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ProjectForVendista.Models.Auth;
    public sealed class Configuration : DbMigrationsConfiguration<ProjectForVendista.Models.ModelsContext.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProjectForVendista.Models.ModelsContext.Context context)
        {
            context.users.AddOrUpdate
                (
                new User { Name="part",Password = "part"},
                new User { Name = "user2", Password = "password2" },
                new User { Name = "user1", Password = "password1" }
                );
        }
    }
}
