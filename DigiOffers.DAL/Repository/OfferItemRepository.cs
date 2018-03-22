using System.Collections.Generic;
using System.Linq;
using DigiOffers.Model.Entities;

namespace DigiOffers.DAL.Repository
{
	public class OfferItemRepository : RepositoryBase<OfferItem>, IOfferItemRepository
	{
		public OfferItemRepository(DigiOfferDbContext context) : base(context)
		{
		}

		public List<OfferItem> GetList()
		{
			return DbContext.OfferItems
				.Where(x => x.Active)
				.OrderByDescending(x => x.ID)
				.ToList();
		}

		public override OfferItem Find(int id)
		{
			return DbContext.OfferItems
				.Where(x => x.ID == id && x.Active)
				.FirstOrDefault();
		}
	}
}
