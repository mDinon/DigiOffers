using System.Collections.Generic;
using DigiOffers.Model.Entities;

namespace DigiOffers.DAL.Repository
{
	public interface IClientRepository : IRepositoryBase<Client>
	{
		List<Client> GetList();
	}
}
