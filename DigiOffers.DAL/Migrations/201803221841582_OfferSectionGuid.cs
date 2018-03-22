namespace DigiOffers.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OfferSectionGuid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OfferSections", "Guid", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OfferSections", "Guid");
        }
    }
}
