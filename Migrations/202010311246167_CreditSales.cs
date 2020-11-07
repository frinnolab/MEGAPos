namespace MEGAPos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreditSales : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CreditSales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(),
                        Item_Name = c.String(),
                        QtySold = c.Decimal(precision: 18, scale: 2),
                        AmountCost = c.Decimal(precision: 18, scale: 2),
                        AmountPaid = c.Decimal(precision: 18, scale: 2),
                        AmountBalance = c.Decimal(precision: 18, scale: 2),
                        AmountTotal = c.Decimal(precision: 18, scale: 2),
                        UniId = c.Int(),
                        Unit_Name = c.String(),
                        Customer_Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CreditSales");
        }
    }
}
