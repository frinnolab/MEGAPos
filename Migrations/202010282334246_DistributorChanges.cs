namespace MEGAPos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DistributorChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Distributors", "Email", c => c.String());
            AddColumn("dbo.Distributors", "User_Id", c => c.String());
            DropColumn("dbo.Distributors", "CompanyName");
            DropColumn("dbo.Distributors", "Distirbutor_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Distributors", "Distirbutor_Id", c => c.String());
            AddColumn("dbo.Distributors", "CompanyName", c => c.String());
            DropColumn("dbo.Distributors", "User_Id");
            DropColumn("dbo.Distributors", "Email");
        }
    }
}
