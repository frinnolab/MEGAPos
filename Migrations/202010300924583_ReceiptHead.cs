namespace MEGAPos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReceiptHead : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Receipt_Head",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        SalesDetailId = c.Int(),
                        CustomerName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Sales_Detail", "CustomerName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sales_Detail", "CustomerName");
            DropTable("dbo.Receipt_Head");
        }
    }
}
