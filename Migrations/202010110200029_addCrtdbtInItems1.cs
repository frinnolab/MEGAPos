namespace MEGAPos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCrtdbtInItems1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "Created_By", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "Created_By");
        }
    }
}
