namespace MEGAPos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Receipts0 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Receipt_Detail",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Item_Name = c.String(),
                        QtySold = c.Decimal(precision: 18, scale: 2),
                        AmountCost = c.Decimal(precision: 18, scale: 2),
                        AmountPaid = c.Decimal(precision: 18, scale: 2),
                        Receipt_Head_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Receipt_Detail");
        }
    }
}
