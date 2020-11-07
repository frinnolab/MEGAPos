namespace MEGAPos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SalesDetailChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sales_Detail", "AmountPaid", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sales_Detail", "AmountPaid");
        }
    }
}
