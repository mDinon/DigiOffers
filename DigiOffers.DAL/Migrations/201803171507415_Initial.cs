namespace DigiOffers.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(nullable: false),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        Sex = c.String(nullable: false),
                        Active = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Offers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ClientID = c.Int(nullable: false),
                        DeliveryDate = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Clients", t => t.ClientID, cascadeDelete: true)
                .Index(t => t.ClientID);
            
            CreateTable(
                "dbo.OfferNotes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Note = c.String(nullable: false),
                        OfferID = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Offers", t => t.OfferID, cascadeDelete: true)
                .Index(t => t.OfferID);
            
            CreateTable(
                "dbo.OfferSections",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        OfferID = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Offers", t => t.OfferID, cascadeDelete: true)
                .Index(t => t.OfferID);
            
            CreateTable(
                "dbo.OfferItems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        UnitOfMeasurement = c.String(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OfferSectionID = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.OfferSections", t => t.OfferSectionID, cascadeDelete: true)
                .Index(t => t.OfferSectionID);
            
            CreateTable(
                "dbo.Log",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Active = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OfferItems", "OfferSectionID", "dbo.OfferSections");
            DropForeignKey("dbo.OfferSections", "OfferID", "dbo.Offers");
            DropForeignKey("dbo.OfferNotes", "OfferID", "dbo.Offers");
            DropForeignKey("dbo.Offers", "ClientID", "dbo.Clients");
            DropIndex("dbo.OfferItems", new[] { "OfferSectionID" });
            DropIndex("dbo.OfferSections", new[] { "OfferID" });
            DropIndex("dbo.OfferNotes", new[] { "OfferID" });
            DropIndex("dbo.Offers", new[] { "ClientID" });
            DropTable("dbo.Logs");
            DropTable("dbo.OfferItems");
            DropTable("dbo.OfferSections");
            DropTable("dbo.OfferNotes");
            DropTable("dbo.Offers");
            DropTable("dbo.Clients");
        }
    }
}
