namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Thrid : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        StreetName = c.String(),
                        HouseNo = c.Int(nullable: false),
                        Floor = c.Int(nullable: false),
                        Direction = c.String(),
                        CompanyAddressOrDeliveryAddress = c.Boolean(nullable: false),
                        CityId = c.Guid(nullable: false),
                        CountryId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.City", t => t.CityId, cascadeDelete: true)
                .ForeignKey("dbo.Country", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CityId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.City",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CityName = c.String(),
                        PostalCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Country",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CountryName = c.String(),
                        CountryCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        CorporateIdentificationNumber = c.String(),
                        LoginId = c.Guid(nullable: false),
                        Address_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Address", t => t.Address_Id)
                .ForeignKey("dbo.Login", t => t.LoginId, cascadeDelete: true)
                .Index(t => t.LoginId)
                .Index(t => t.Address_Id);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Company", "LoginId", "dbo.Login");
            DropForeignKey("dbo.Company", "Address_Id", "dbo.Address");
            DropForeignKey("dbo.Address", "CountryId", "dbo.Country");
            DropForeignKey("dbo.Address", "CityId", "dbo.City");
            DropIndex("dbo.Company", new[] { "Address_Id" });
            DropIndex("dbo.Company", new[] { "LoginId" });
            DropIndex("dbo.Address", new[] { "CountryId" });
            DropIndex("dbo.Address", new[] { "CityId" });
            DropTable("dbo.Login");
            DropTable("dbo.Company");
            DropTable("dbo.Country");
            DropTable("dbo.City");
            DropTable("dbo.Address");
        }
    }
}
