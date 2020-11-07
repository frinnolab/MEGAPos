namespace MEGAPos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SalesChanges0 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sales_Detail", "Amount", c => c.Decimal(precision: 18, scale: 2));
            DropColumn("dbo.Sales_Detail", "ItemCode");
            DropColumn("dbo.Sales_Detail", "Description");
            DropColumn("dbo.Sales_Detail", "Qty_Available");
            DropColumn("dbo.Sales_Detail", "Price");
            DropColumn("dbo.Sales_Detail", "Item_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sales_Detail", "Item_id", c => c.Int());
            AddColumn("dbo.Sales_Detail", "Price", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Sales_Detail", "Qty_Available", c => c.Int());
            AddColumn("dbo.Sales_Detail", "Description", c => c.String());
            AddColumn("dbo.Sales_Detail", "ItemCode", c => c.String());
            DropColumn("dbo.Sales_Detail", "Amount");
        }
    }
}
