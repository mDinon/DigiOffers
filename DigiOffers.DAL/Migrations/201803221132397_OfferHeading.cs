namespace DigiOffers.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OfferHeading : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Offers", "Heading", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Offers", "Heading");
        }
    }
}
