namespace MEGAPos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VATz : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VATs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Value = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.VATs");
        }
    }
}
