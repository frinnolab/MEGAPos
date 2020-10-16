namespace MEGAPos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SalesHeadInput : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Sales_Header", "Seller_Id", c => c.String());
            AlterColumn("dbo.Sales_Header", "Buyer_Id", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sales_Header", "Buyer_Id", c => c.Int());
            AlterColumn("dbo.Sales_Header", "Seller_Id", c => c.Int());
        }
    }
}
