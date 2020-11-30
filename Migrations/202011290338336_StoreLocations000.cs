namespace MEGAPos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StoreLocations000 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sales_Header", "Store_Location_Id", c => c.Int());
            AddColumn("dbo.Sales_Header", "Store_Location_Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sales_Header", "Store_Location_Name");
            DropColumn("dbo.Sales_Header", "Store_Location_Id");
        }
    }
}
