using System.Collections.Generic;
using DigiOffers.Model.Entities;

namespace DigiOffers.DAL.Repository
{
	public interface IOfferRepository : IRepositoryBase<Offer>
	{
		List<Offer> GetList();
	}
}
