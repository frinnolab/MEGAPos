namespace MEGAPos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFieldsToItem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "ItemCode", c => c.String());
            AddColumn("dbo.Items", "PriceList_id", c => c.Int());
            AddColumn("dbo.Items", "Category_id", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "Category_id");
            DropColumn("dbo.Items", "PriceList_id");
            DropColumn("dbo.Items", "ItemCode");
        }
    }
}
