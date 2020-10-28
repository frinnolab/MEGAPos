namespace MEGAPos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerTypeField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "User_Id", c => c.String());
            AddColumn("dbo.Customers", "CustomerType_Id", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "CustomerType_Id");
            DropColumn("dbo.Customers", "User_Id");
        }
    }
}
