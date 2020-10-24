namespace MEGAPos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VendorItems : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VendorItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Vendor_Id = c.Int(),
                        Item_Id = c.Int(),
                        Item_Name = c.String(),
                        QuantityBal = c.Decimal(precision: 18, scale: 2),
                        unit_id = c.Int(),
                        Unit_Name = c.String(),
                        Vendor_TypeID = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.VendorItems");
        }
    }
}
