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
				.Where(x => x.Active)
				.OrderByDescending(x => x.ID)
				.ToList();
		}

		public override Client Find(int id)
		{
			return DbContext.Clients
				.Include(x => x.Offers)
				.Where(x => x.ID == id && x.Active)
				.FirstOrDefault();
		}

		public Client Find(Client client)
		{
			return DbContext.Clients
				.Include(x => x.Offers)
				.Where(x => x.Email == client.Email && x.FirstName == client.FirstName && x.LastName == client.LastName && x.PhoneNumber == client.PhoneNumber && x.Title == client.Title && x.Active)
				.FirstOrDefault();
		}
	}
}
