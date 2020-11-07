namespace MEGAPos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PriceListFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PriceLists", "Item_Name", c => c.String());
            AddColumn("dbo.PriceLists", "PriceType_Name", c => c.String());
            AddColumn("dbo.PriceLists", "Unit_Id", c => c.Int());
            AddColumn("dbo.PriceLists", "Unit_Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PriceLists", "Unit_Name");
            DropColumn("dbo.PriceLists", "Unit_Id");
            DropColumn("dbo.PriceLists", "PriceType_Name");
            DropColumn("dbo.PriceLists", "Item_Name");
        }
    }
}
