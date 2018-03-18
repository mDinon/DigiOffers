using System.Collections.Generic;
using DigiOffers.Model.Entities;

namespace DigiOffers.DAL.Repository
{
	public interface IOfferNoteRepository : IRepositoryBase<OfferNote>
	{
		List<OfferNote> GetList();
	}
}
