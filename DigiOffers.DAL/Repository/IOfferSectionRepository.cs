using System.Collections.Generic;
using DigiOffers.Model.Entities;

namespace DigiOffers.DAL.Repository
{
	public interface IOfferSectionRepository : IRepositoryBase<OfferSection>
	{
		List<OfferSection> GetList();
	}
}
