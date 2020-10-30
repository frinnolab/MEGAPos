namespace MEGAPos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DistributorTypeChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Distributors", "Distributor_TypeID", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Distributors", "Distributor_TypeID");
        }
    }
}
