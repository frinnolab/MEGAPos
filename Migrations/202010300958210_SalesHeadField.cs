namespace MEGAPos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SalesHeadField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sales_Header", "CustomerName", c => c.String());
            AddColumn("dbo.Sales_Header", "CustomerType_Id", c => c.Int());
            AddColumn("dbo.Sales_Header", "CustomerType_Name", c => c.String());
            DropColumn("dbo.Sales_Header", "Buyer_Id");
            DropColumn("dbo.Sales_Header", "Buyer_Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sales_Header", "Buyer_Name", c => c.String());
            AddColumn("dbo.Sales_Header", "Buyer_Id", c => c.String());
            DropColumn("dbo.Sales_Header", "CustomerType_Name");
            DropColumn("dbo.Sales_Header", "CustomerType_Id");
            DropColumn("dbo.Sales_Header", "CustomerName");
        }
    }
}
