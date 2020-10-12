namespace MEGAPos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addQtyInItems : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "Qty_In", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "Qty_In");
        }
    }
}
