namespace MEGAPos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsTaxableToItem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "Is_Taxable", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "Is_Taxable");
        }
    }
}
