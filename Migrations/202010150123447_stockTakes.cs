namespace MEGAPos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stockTakes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Stock_Take_Detail",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Item_id = c.Int(),
                        QuantityChecked = c.Decimal(precision: 18, scale: 2),
                        UOM_id = c.Int(),
                        Stock_Take_Head_id = c.Int(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Stock_Take_Head",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        CheckDate = c.DateTime(),
                        CheckedBy = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Stock_Take_Head");
            DropTable("dbo.Stock_Take_Detail");
        }
    }
}
