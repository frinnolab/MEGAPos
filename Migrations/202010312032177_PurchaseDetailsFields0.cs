namespace MEGAPos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PurchaseDetailsFields0 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Purchase_Detail", "VendorType_Id", c => c.Int());
            DropColumn("dbo.Purchase_Detail", "Vendor_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Purchase_Detail", "Vendor_Id", c => c.Int());
            DropColumn("dbo.Purchase_Detail", "VendorType_Id");
        }
    }
}
