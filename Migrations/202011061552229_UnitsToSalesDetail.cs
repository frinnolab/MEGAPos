namespace MEGAPos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UnitsToSalesDetail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sales_Detail", "UniId", c => c.Int());
            AddColumn("dbo.Sales_Detail", "Unit_Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sales_Detail", "Unit_Name");
            DropColumn("dbo.Sales_Detail", "UniId");
        }
    }
}
