using System.Collections.Generic;
using DigiOffers.Model.Entities;

namespace DigiOffers.DAL.Repository
{
	public interface IOfferItemRepository : IRepositoryBase<OfferItem>
	{
		List<OfferItem> GetList();
	}
}
