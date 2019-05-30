namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeForeignOnAdreess : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Address", "CityId", "dbo.City");
            DropForeignKey("dbo.Address", "CountryId", "dbo.Country");
            DropIndex("dbo.Address", new[] { "CityId" });
            DropIndex("dbo.Address", new[] { "CountryId" });
            DropColumn("dbo.Address", "CityId");
            DropColumn("dbo.Address", "CountryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Address", "CountryId", c => c.Guid(nullable: false));
            AddColumn("dbo.Address", "CityId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Address", "CountryId");
            CreateIndex("dbo.Address", "CityId");
            AddForeignKey("dbo.Address", "CountryId", "dbo.Country", "CountryId", cascadeDelete: true);
            AddForeignKey("dbo.Address", "CityId", "dbo.City", "CityId", cascadeDelete: true);
        }
    }
}
