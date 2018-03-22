namespace DigiOffers.DAL.Migrations
{
	using System;
	using System.Data.Entity;
	using System.Data.Entity.Migrations;
	using System.Linq;

	internal sealed class Configuration : DbMigrationsConfiguration<DigiOffers.DAL.DigiOfferDbContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
		}

		protected override void Seed(DigiOffers.DAL.DigiOfferDbContext context)
		{
			//  This method will be called after migrating to the latest version.

			//  You can use the DbSet<T>.AddOrUpdate() helper extension method 
			//  to avoid creating duplicate seed data.

			context.Clients.AddOrUpdate(x => x.ID,
				new Model.Entities.Client() { Active = true, DateCreated = new DateTime(2018, 3, 18), Email = "test.test@test.com", FirstName = "Pero", LastName = "Periæ", ID = 1, PhoneNumber = "013265478", Sex = "M" },
				new Model.Entities.Client() { Active = true, DateCreated = new DateTime(2018, 1, 18), Email = "mail.mail@mail.com", FirstName = "Iva", LastName = "Iviæ", ID = 2, PhoneNumber = "0915487678", Sex = "M" });

			context.Offers.AddOrUpdate(x => x.ID,
				new Model.Entities.Offer() { ID = 1, Active = true, Heading = "Ponuda 1", ClientID = 1, DateCreated = new DateTime(2018, 3, 18), DeliveryDate = new DateTime(2018, 3, 18) },
				new Model.Entities.Offer() { ID = 2, Active = true, Heading = "Ponuda 2", ClientID = 2, DateCreated = new DateTime(2018, 1, 18), DeliveryDate = new DateTime(2018, 3, 18) },
				new Model.Entities.Offer() { ID = 3, Active = true, Heading = "Ponuda 3", ClientID = 1, DateCreated = new DateTime(2018, 3, 18), DeliveryDate = new DateTime(2018, 5, 18) });

			context.OfferNotes.AddOrUpdate(x => x.ID,
				new Model.Entities.OfferNote() { ID = 1, Active = true, DateCreated = new DateTime(2018, 3, 18), OfferID = 1, Note = "Test note" },
				new Model.Entities.OfferNote() { ID = 2, Active = true, DateCreated = new DateTime(2018, 3, 18), OfferID = 1, Note = "Test note2" },
				new Model.Entities.OfferNote() { ID = 3, Active = true, DateCreated = new DateTime(2018, 1, 18), OfferID = 2, Note = "Test note3" });

			context.OfferSections.AddOrUpdate(x => x.ID,
				new Model.Entities.OfferSection() { ID = 1, Guid = Guid.NewGuid(), Active = true, DateCreated = new DateTime(2018, 3, 18), Name = "Sekcija1", OfferID = 1 },
				new Model.Entities.OfferSection() { ID = 2, Guid = Guid.NewGuid(), Active = true, DateCreated = new DateTime(2018, 3, 18), Name = "Sekcija2", OfferID = 1 },
				new Model.Entities.OfferSection() { ID = 3, Guid = Guid.NewGuid(), Active = true, DateCreated = new DateTime(2018, 1, 18), Name = "Sekcija3", OfferID = 2 });

			context.OfferItems.AddOrUpdate(x => x.ID,
				new Model.Entities.OfferItem() { ID = 1, Active = true, DateCreated = new DateTime(2018, 3, 18), Name = "Item1", OfferSectionID = 1, Price = 100, Quantity = 1, UnitOfMeasurement = "m" },
				new Model.Entities.OfferItem() { ID = 2, Active = true, DateCreated = new DateTime(2018, 3, 18), Name = "Item2", OfferSectionID = 1, Price = 50, Quantity = 1, UnitOfMeasurement = "m" },
				new Model.Entities.OfferItem() { ID = 3, Active = true, DateCreated = new DateTime(2018, 3, 18), Name = "Item1", OfferSectionID = 2, Price = 100, Quantity = 5, UnitOfMeasurement = "m" },
				new Model.Entities.OfferItem() { ID = 4, Active = true, DateCreated = new DateTime(2018, 1, 18), Name = "Item1", OfferSectionID = 3, Price = 1000, Quantity = 2, UnitOfMeasurement = "m" });
		}
	}
}
