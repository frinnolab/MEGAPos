namespace MEGAPos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QtyBalToStockWatch : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StockWatches", "QtyBalance", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.StockWatches", "QtyBalance");
        }
    }
}
