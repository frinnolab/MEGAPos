namespace MEGAPos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Receipts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Receipt_Head", "StoreLocationName", c => c.String());
            AddColumn("dbo.Receipt_Head", "AmountTotal", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Receipt_Head", "AmountTotal");
            DropColumn("dbo.Receipt_Head", "StoreLocationName");
        }
    }
}
