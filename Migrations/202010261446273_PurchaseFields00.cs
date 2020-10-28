namespace MEGAPos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PurchaseFields00 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Purchase_Detail", "Vendor_Id", c => c.Int());
            AddColumn("dbo.Purchase_Detail", "Vendor_Name", c => c.String());
            AddColumn("dbo.Purchase_Detail", "VendorType_Id", c => c.Int());
            AddColumn("dbo.Purchase_Detail", "VendorType_Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Purchase_Detail", "VendorType_Name");
            DropColumn("dbo.Purchase_Detail", "VendorType_Id");
            DropColumn("dbo.Purchase_Detail", "Vendor_Name");
            DropColumn("dbo.Purchase_Detail", "Vendor_Id");
        }
    }
}
