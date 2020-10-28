namespace MEGAPos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PurchaseItemNameField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Purchase_Detail", "Item_Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Purchase_Detail", "Item_Name");
        }
    }
}
