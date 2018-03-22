using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DigiOffers.Model.Entities;

namespace DigiOffers.DAL.Repository
{
	public class OfferRepository : RepositoryBase<Offer>, IOfferRepository
	{
		public OfferRepository(DigiOfferDbContext context) : base(context)
		{
		}

		public List<Offer> GetList()
		{
			return DbContext.Offers
				.Include(x => x.OfferSections)
				.Include(x => x.OfferNotes)
				.Where(x => x.Active)
				.OrderByDescending(x => x.ID)
				.ToList();
		}

		public override Offer Find(int id)
		{
			return DbContext.Offers
				.Include(x => x.OfferSections)
				.Include(x => x.OfferNotes)
				.Where(x => x.ID == id && x.Active)
				.FirstOrDefault();
		}
	}
}
