namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
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
                        CityId = c.Guid(nullable: false),
                        CityName = c.String(),
                        PostalCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CityId);
            
            CreateTable(
                "dbo.Country",
                c => new
                    {
                        CountryId = c.Guid(nullable: false),
                        CountryName = c.String(),
                        CountryCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CountryId);
            
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        CustomerNumber = c.Long(nullable: false),
                        Name = c.String(),
                        CorporateIdentificationNumber = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Level = c.Int(nullable: false),
                        CityId = c.Guid(nullable: false),
                        CountryId = c.Guid(nullable: false),
                        CompletePassword = c.Binary(),
                        PasswordSalt = c.Binary(),
                    })
                .PrimaryKey(t => t.CustomerNumber)
                .ForeignKey("dbo.City", t => t.CityId, cascadeDelete: true)
                .ForeignKey("dbo.Country", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CityId)
                .Index(t => t.CountryId);
            
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
            DropForeignKey("dbo.Company", "CountryId", "dbo.Country");
            DropForeignKey("dbo.Company", "CityId", "dbo.City");
            DropForeignKey("dbo.Address", "CountryId", "dbo.Country");
            DropForeignKey("dbo.Address", "CityId", "dbo.City");
            DropIndex("dbo.User", new[] { "CustomerNumber" });
            DropIndex("dbo.Company", new[] { "CountryId" });
            DropIndex("dbo.Company", new[] { "CityId" });
            DropIndex("dbo.Address", new[] { "CountryId" });
            DropIndex("dbo.Address", new[] { "CityId" });
            DropTable("dbo.User");
            DropTable("dbo.Company");
            DropTable("dbo.Country");
            DropTable("dbo.City");
            DropTable("dbo.Address");
        }
    }
}
