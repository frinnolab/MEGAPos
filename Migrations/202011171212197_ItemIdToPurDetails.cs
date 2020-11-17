namespace MEGAPos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ItemIdToPurDetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Purchase_Detail", "Item_Id", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Purchase_Detail", "Item_Id");
        }
    }
}
