namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class databaseUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Company", "Address_Id", "dbo.Address");
            DropForeignKey("dbo.Company", "LoginId", "dbo.Login");
            DropIndex("dbo.Company", new[] { "LoginId" });
            DropIndex("dbo.Company", new[] { "Address_Id" });
            DropPrimaryKey("dbo.Company");
            AddColumn("dbo.Company", "CustomerNumber", c => c.Long(nullable: false, identity: true));
            AddColumn("dbo.Company", "CorporateIdentificationNumber", c => c.String());
            AddColumn("dbo.Company", "Address", c => c.String());
            AddColumn("dbo.Company", "Phone", c => c.String());
            AddColumn("dbo.Company", "Email", c => c.String());
            AddColumn("dbo.Company", "Level", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Company", "CustomerNumber");
            DropColumn("dbo.Company", "Id");
            DropColumn("dbo.Company", "Cvr");
            DropColumn("dbo.Company", "LoginId");
            DropColumn("dbo.Company", "Address_Id");
            DropTable("dbo.Login");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Login",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Phone = c.Int(nullable: false),
                        Email = c.String(),
                        Level = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Company", "Address_Id", c => c.Guid());
            AddColumn("dbo.Company", "LoginId", c => c.Guid(nullable: false));
            AddColumn("dbo.Company", "Cvr", c => c.String());
            AddColumn("dbo.Company", "Id", c => c.String(nullable: false, maxLength: 128));
            DropPrimaryKey("dbo.Company");
            DropColumn("dbo.Company", "Level");
            DropColumn("dbo.Company", "Email");
            DropColumn("dbo.Company", "Phone");
            DropColumn("dbo.Company", "Address");
            DropColumn("dbo.Company", "CorporateIdentificationNumber");
            DropColumn("dbo.Company", "CustomerNumber");
            AddPrimaryKey("dbo.Company", "Id");
            CreateIndex("dbo.Company", "Address_Id");
            CreateIndex("dbo.Company", "LoginId");
            AddForeignKey("dbo.Company", "LoginId", "dbo.Login", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Company", "Address_Id", "dbo.Address", "Id");
        }
    }
}
