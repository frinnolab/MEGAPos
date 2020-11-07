namespace MEGAPos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PriceTypes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PriceTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Unit_Id = c.Int(),
                        Unit_Name = c.String(),
                        ItemCount = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.SalesTypes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SalesTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SaleName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.PriceTypes");
        }
    }
}
