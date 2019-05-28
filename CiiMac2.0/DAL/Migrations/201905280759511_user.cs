namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class user : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Level = c.Int(nullable: false),
                        CustomerNumber = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Company", t => t.CustomerNumber, cascadeDelete: true)
                .Index(t => t.CustomerNumber);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "CustomerNumber", "dbo.Company");
            DropIndex("dbo.User", new[] { "CustomerNumber" });
            DropTable("dbo.User");
        }
    }
}
