namespace MEGAPos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Companies : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Receipt_Head", "SalesDetailId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Receipt_Head", "SalesDetailId", c => c.Int());
        }
    }
}
