namespace MEGAPos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PurchaseFields0 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Purchase_Head", "Vendor_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Purchase_Head", "Vendor_Id", c => c.Int());
        }
    }
}
