namespace MEGAPos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VatField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "Is_VAT_Id", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "Is_VAT_Id");
        }
    }
}
