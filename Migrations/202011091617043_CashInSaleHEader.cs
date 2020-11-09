namespace MEGAPos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CashInSaleHEader : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sales_Header", "Cash_In", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sales_Header", "Cash_In");
        }
    }
}
