using System.Data.Entity;
using DigiOffers.Model.Entities;

namespace DigiOffers.DAL
{
	public class DigiOfferDbContext : DbContext
	{
		public DigiOfferDbContext() : base("DigiOfferDbContext")
		{
		}
		public static DigiOfferDbContext Create()
		{
			return new DigiOfferDbContext();
		}

		public DbSet<Client> Clients { get; set; }
		public DbSet<Log> Log { get; set; }
		public DbSet<Offer> Offers { get; set; }
		public DbSet<OfferItem> OfferItems { get; set; }
		public DbSet<OfferNote> OfferNotes { get; set; }
		public DbSet<OfferSection> OfferSections { get; set; }
	}
}
