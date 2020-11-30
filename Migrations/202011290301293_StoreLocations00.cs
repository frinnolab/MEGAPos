namespace MEGAPos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StoreLocations00 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StockWatches", "StoreLocationId", c => c.Int());
            AddColumn("dbo.StockWatches", "StoreLocationName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.StockWatches", "StoreLocationName");
            DropColumn("dbo.StockWatches", "StoreLocationId");
        }
    }
}
