namespace MEGAPos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StoreLocations0 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Store_Location", "StoreName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Store_Location", "StoreName");
        }
    }
}
