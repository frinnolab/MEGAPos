namespace MEGAPos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SalesCahnges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CreditSales", "Location_Name", c => c.String());
            AddColumn("dbo.CreditSales", "Location_id", c => c.Int());
            AddColumn("dbo.Sales_Detail", "Location_Id", c => c.Int());
            AddColumn("dbo.Sales_Detail", "Location_Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sales_Detail", "Location_Name");
            DropColumn("dbo.Sales_Detail", "Location_Id");
            DropColumn("dbo.CreditSales", "Location_id");
            DropColumn("dbo.CreditSales", "Location_Name");
        }
    }
}
