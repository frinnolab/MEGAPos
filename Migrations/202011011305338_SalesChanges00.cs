namespace MEGAPos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SalesChanges00 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CreditSales", "Sales_Header_id", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CreditSales", "Sales_Header_id");
        }
    }
}
