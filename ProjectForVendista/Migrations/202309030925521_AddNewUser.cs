namespace ProjectForVendista.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewUser : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Users(Name, Password) Values('part','part')");
        }
        
        public override void Down()
        {
        }
    }
}
