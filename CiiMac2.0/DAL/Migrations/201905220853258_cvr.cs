namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cvr : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Company", "Cvr", c => c.String());
            DropColumn("dbo.Company", "CorporateIdentificationNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Company", "CorporateIdentificationNumber", c => c.String());
            DropColumn("dbo.Company", "Cvr");
        }
    }
}
