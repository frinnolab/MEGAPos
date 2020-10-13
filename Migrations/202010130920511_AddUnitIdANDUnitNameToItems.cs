namespace MEGAPos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUnitIdANDUnitNameToItems : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "Unit_Id", c => c.Int());
            AddColumn("dbo.Items", "Unit_Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "Unit_Name");
            DropColumn("dbo.Items", "Unit_Id");
        }
    }
}
