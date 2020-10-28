namespace MEGAPos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PurchaseItemNameField0 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Purchase_Detail", "PurchaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Purchase_Detail", "PurchaseDateString", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Purchase_Detail", "PurchaseDateString");
            DropColumn("dbo.Purchase_Detail", "PurchaseDate");
        }
    }
}
