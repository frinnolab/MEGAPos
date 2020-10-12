namespace MEGAPos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class unitsofmeasure : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Items", "Qty_In", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Items", "Created_By", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Items", "Created_By", c => c.Int());
            AlterColumn("dbo.Items", "Qty_In", c => c.Int());
        }
    }
}
