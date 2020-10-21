namespace MEGAPos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerTypes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "CustomerTypeId", c => c.Int());
            AddColumn("dbo.Items", "CustomerType_Id", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "CustomerType_Id");
            DropColumn("dbo.Customers", "CustomerTypeId");
        }
    }
}
