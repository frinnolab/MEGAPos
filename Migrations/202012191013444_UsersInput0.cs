namespace MEGAPos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UsersInput0 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Company_Id", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Company_Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Company_Name");
            DropColumn("dbo.AspNetUsers", "Company_Id");
        }
    }
}
