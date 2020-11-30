namespace MEGAPos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TotalBal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CreditSales", "TotalBalance", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CreditSales", "TotalBalance");
        }
    }
}
