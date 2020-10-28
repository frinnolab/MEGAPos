namespace MEGAPos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PurchaseFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Purchase_Detail", "PurchaseType_Id", c => c.Int());
            AddColumn("dbo.Purchase_Detail", "PurchaseType_Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Purchase_Detail", "PurchaseType_Name");
            DropColumn("dbo.Purchase_Detail", "PurchaseType_Id");
        }
    }
}
