namespace MEGAPos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PurchaseModels0 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Purchase_Detail",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Item_id = c.Int(),
                        Qunatity_In = c.Decimal(precision: 18, scale: 2),
                        Price = c.Decimal(precision: 18, scale: 2),
                        Purchase_Head_id = c.Int(),
                        Unit_id = c.Int(),
                        Unit_Name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Purchase_Head",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Vendor_Id = c.Int(),
                        Purchased_by = c.Int(),
                        Purchase_Date = c.DateTime(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Purchase_Head");
            DropTable("dbo.Purchase_Detail");
        }
    }
}
