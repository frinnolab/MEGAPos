namespace MEGAPos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class unitsofmeasure0 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.U_O_M",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Unit_Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.U_O_M");
        }
    }
}
