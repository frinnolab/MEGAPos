namespace MEGAPos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CashInFields0 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CreditSales", "Cash_In", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Sales_Detail", "Cash_In", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sales_Detail", "Cash_In");
            DropColumn("dbo.CreditSales", "Cash_In");
        }
    }
}
