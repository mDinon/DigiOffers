namespace DigiOffers.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OfferNotesGuid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OfferNotes", "Guid", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OfferNotes", "Guid");
        }
    }
}
