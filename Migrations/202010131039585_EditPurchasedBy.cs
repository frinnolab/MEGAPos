namespace MEGAPos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditPurchasedBy : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Purchase_Head", "Purchased_by", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Purchase_Head", "Purchased_by", c => c.Int());
        }
    }
}
