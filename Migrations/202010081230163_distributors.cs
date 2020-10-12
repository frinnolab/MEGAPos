namespace MEGAPos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class distributors : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Distributors",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        Address = c.String(),
                        Contact = c.String(),
                        Distirbutor_Id = c.String(),
                        Distributor_Name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Distributors");
        }
    }
}
