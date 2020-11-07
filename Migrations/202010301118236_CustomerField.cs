namespace MEGAPos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Created_By", c => c.String());
            DropColumn("dbo.Customers", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "User_Id", c => c.String());
            DropColumn("dbo.Customers", "Created_By");
        }
    }
}
