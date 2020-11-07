namespace MEGAPos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PurchaseDetailsFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Purchase_Detail", "Amount", c => c.Decimal(precision: 18, scale: 2));
            DropColumn("dbo.Purchase_Detail", "Item_id");
            DropColumn("dbo.Purchase_Detail", "Price");
            DropColumn("dbo.Purchase_Detail", "PurchaseDateString");
            DropColumn("dbo.Purchase_Detail", "PurchaseType_Id");
            DropColumn("dbo.Purchase_Detail", "PurchaseType_Name");
            DropColumn("dbo.Purchase_Detail", "VendorType_Id");
            DropColumn("dbo.Purchase_Detail", "VendorType_Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Purchase_Detail", "VendorType_Name", c => c.String());
            AddColumn("dbo.Purchase_Detail", "VendorType_Id", c => c.Int());
            AddColumn("dbo.Purchase_Detail", "PurchaseType_Name", c => c.String());
            AddColumn("dbo.Purchase_Detail", "PurchaseType_Id", c => c.Int());
            AddColumn("dbo.Purchase_Detail", "PurchaseDateString", c => c.String());
            AddColumn("dbo.Purchase_Detail", "Price", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Purchase_Detail", "Item_id", c => c.Int());
            DropColumn("dbo.Purchase_Detail", "Amount");
        }
    }
}
