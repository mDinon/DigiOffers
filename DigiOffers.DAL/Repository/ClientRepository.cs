using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DigiOffers.Model.Entities;

namespace DigiOffers.DAL.Repository
{
	public class ClientRepository : RepositoryBase<Client>, IClientRepository
	{
		public ClientRepository(DigiOfferDbContext context) : base(context)
		{
		}

		public List<Client> GetList()
		{
			return DbContext.Clients
				.Include(x => x.Offers)
				.OrderByDescending(x => x.ID)
				.ToList();
		}

		public override Client Find(int id)
		{
			return DbContext.Clients
				.Include(x => x.Offers)
				.Where(x => x.ID == id)
				.FirstOrDefault();
		}
	}
}
