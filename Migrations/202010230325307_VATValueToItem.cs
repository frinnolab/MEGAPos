namespace MEGAPos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VATValueToItem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "VatValue", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "VatValue");
        }
    }
}
