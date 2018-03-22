using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DigiOffers.Model.Entities;

namespace DigiOffers.DAL.Repository
{
	public class OfferSectionRepository : RepositoryBase<OfferSection>, IOfferSectionRepository
	{
		public OfferSectionRepository(DigiOfferDbContext context) : base(context)
		{
		}

		public List<OfferSection> GetList()
		{
			return DbContext.OfferSections
				.Include(x => x.OfferItems)
				.Where(x => x.Active)
				.OrderByDescending(x => x.ID)
				.ToList();
		}

		public override OfferSection Find(int id)
		{
			return DbContext.OfferSections
				.Include(x => x.OfferItems)
				.Where(x => x.ID == id && x.Active)
				.FirstOrDefault();
		}
	}
}
