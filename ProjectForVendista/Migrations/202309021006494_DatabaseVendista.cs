namespace ProjectForVendista.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseVendista : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.History",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        Command = c.String(),
                        Param1 = c.String(),
                        Param2 = c.String(),
                        Param3 = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
           
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.History");
        }
    }
}
