using DigiOffers.Model.Entities;

namespace DigiOffers.DAL.Repository
{
	public interface IRepositoryBase<TEntity> where TEntity : EntityBase
	{
		TEntity Find(int id);
		TEntity Add(TEntity model);
		void Update(TEntity model);
		void Delete(TEntity model);
		void Save();
	}
}
