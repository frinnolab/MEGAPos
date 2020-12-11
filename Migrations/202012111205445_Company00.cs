namespace MEGAPos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Company00 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Companies", "Location_Id", c => c.Int());
            AddColumn("dbo.Companies", "Location", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Companies", "Location");
            DropColumn("dbo.Companies", "Location_Id");
        }
    }
}
