namespace MEGAPos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefNo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sales_Header", "Ref_No", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sales_Header", "Ref_No");
        }
    }
}
