namespace MEGAPos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomersAndSaleField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sales_Header", "Seller_Name", c => c.String());
            AddColumn("dbo.Sales_Header", "Buyer_Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sales_Header", "Buyer_Name");
            DropColumn("dbo.Sales_Header", "Seller_Name");
        }
    }
}
