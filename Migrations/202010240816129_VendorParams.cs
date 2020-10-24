namespace MEGAPos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VendorParams : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vendors", "Vendor_TypeID", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vendors", "Vendor_TypeID");
        }
    }
}
