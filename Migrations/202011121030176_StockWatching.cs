namespace MEGAPos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StockWatching : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StockWatches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(),
                        ItemName = c.String(),
                        QtyIn = c.Decimal(precision: 18, scale: 2),
                        QtyOut = c.Decimal(precision: 18, scale: 2),
                        BuyingPrice = c.Decimal(precision: 18, scale: 2),
                        SellingPrice = c.Decimal(precision: 18, scale: 2),
                        UnitId = c.Int(),
                        UnitName = c.String(),
                        PurchaseId = c.Int(),
                        SalesId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StockWatches");
        }
    }
}
