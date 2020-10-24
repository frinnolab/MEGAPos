namespace MEGAPos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VendorTypes0 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VendorTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.VendorTypes");
        }
    }
}
