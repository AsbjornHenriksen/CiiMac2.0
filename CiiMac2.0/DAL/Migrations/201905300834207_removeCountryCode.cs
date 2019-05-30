namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeCountryCode : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.City", "PostalCode", c => c.String());
            DropColumn("dbo.Country", "CountryCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Country", "CountryCode", c => c.Int(nullable: false));
            AlterColumn("dbo.City", "PostalCode", c => c.Int(nullable: false));
        }
    }
}
