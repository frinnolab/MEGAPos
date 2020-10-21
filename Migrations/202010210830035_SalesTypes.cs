namespace MEGAPos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SalesTypes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SalesTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SaleName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Customers", "CustomerTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "CustomerTypeId", c => c.Int());
            DropTable("dbo.SalesTypes");
        }
    }
}
