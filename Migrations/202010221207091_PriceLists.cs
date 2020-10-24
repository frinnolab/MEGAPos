namespace MEGAPos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PriceLists : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PriceLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Item_Id = c.Int(),
                        PriceType_Id = c.Int(),
                        PriceValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PriceLists");
        }
    }
}
