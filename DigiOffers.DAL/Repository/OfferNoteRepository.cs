using System.Collections.Generic;
using System.Linq;
using DigiOffers.Model.Entities;

namespace DigiOffers.DAL.Repository
{
	public class OfferNoteRepository : RepositoryBase<OfferNote>, IOfferNoteRepository
	{
		public OfferNoteRepository(DigiOfferDbContext context) : base(context)
		{
		}

		public List<OfferNote> GetList()
		{
			return DbContext.OfferNotes
				.OrderByDescending(x => x.ID)
				.ToList();
		}

		public override OfferNote Find(int id)
		{
			return DbContext.OfferNotes
				.Where(x => x.ID == id)
				.FirstOrDefault();
		}
	}
}
