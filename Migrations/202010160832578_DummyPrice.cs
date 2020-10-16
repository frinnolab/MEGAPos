namespace MEGAPos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DummyPrice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "DummyPrice", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "DummyPrice");
        }
    }
}
