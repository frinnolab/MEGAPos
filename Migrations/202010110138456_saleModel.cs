namespace MEGAPos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class saleModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Item_Name = c.String(),
                        Description = c.String(),
                        ItemDateCreated = c.DateTime(),
                        ItemDateUpdate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sales_Detail",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemName = c.String(),
                        ItemCode = c.String(),
                        Description = c.String(),
                        Qty = c.Int(),
                        Qty_Available = c.Int(),
                        Item_id = c.Int(),
                        Sales_Header_id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sales_Header",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Sale_Date = c.DateTime(nullable: false),
                        Seller_Id = c.Int(),
                        Buyer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Sales_Header");
            DropTable("dbo.Sales_Detail");
            DropTable("dbo.Items");
        }
    }
}
