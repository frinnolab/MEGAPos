namespace MEGAPos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SalesChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CreditSales", "SaleDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.CreditSales", "CusTypeId", c => c.Int());
            AddColumn("dbo.CreditSales", "CusTypeName", c => c.String());
            AddColumn("dbo.Sales_Detail", "SaleDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sales_Detail", "SaleDate");
            DropColumn("dbo.CreditSales", "CusTypeName");
            DropColumn("dbo.CreditSales", "CusTypeId");
            DropColumn("dbo.CreditSales", "SaleDate");
        }
    }
}
