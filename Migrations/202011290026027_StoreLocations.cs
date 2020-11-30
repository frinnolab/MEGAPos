namespace MEGAPos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StoreLocations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Store_Location",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Purchase_Head", "Location_Id", c => c.Int());
            AddColumn("dbo.Purchase_Head", "Location_Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Purchase_Head", "Location_Name");
            DropColumn("dbo.Purchase_Head", "Location_Id");
            DropTable("dbo.Store_Location");
        }
    }
}
