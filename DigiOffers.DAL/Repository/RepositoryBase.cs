using System;
using System.Data.Entity;
using System.Linq;
using DigiOffers.Model.Entities;

namespace DigiOffers.DAL.Repository
{
	public abstract class RepositoryBase<TEntity> where TEntity : EntityBase
	{
		protected DigiOfferDbContext DbContext { get; }

		protected RepositoryBase(DigiOfferDbContext context)
		{
			DbContext = context;
		}

		public virtual TEntity Find(int id)
		{
			return DbContext.Set<TEntity>()
				.FirstOrDefault(x => x.ID == id && x.Active);
		}

		public void Save()
		{
			try
			{
				DbContext.SaveChanges();
			}
			catch (Exception ex)
			{
				//TODO: save to file system
			}
		}

		public void LogException(Exception ex)
		{
			DbContext.Log.Add(new Log()
			{
				Active = true,
				DateCreated = DateTime.Now,
				Name = ex.Message,
				Description = ex.StackTrace
			});

			Save();
		}

		public TEntity Add(TEntity model)
		{
			model.DateCreated = DateTime.Now;
			model.Active = true;

			DbContext.Set<TEntity>().Add(model);

			Save();
			return model;
		}

		public void Update(TEntity model)
		{
			model.DateModified = DateTime.Now;
			DbContext.Entry(model).State = EntityState.Modified;

			Save();
		}

		public virtual void Delete(TEntity model)
		{
			model.DateModified = DateTime.Now;
			model.Active = false;
			DbContext.Entry(model).State = EntityState.Modified;

			Save();
		}
	}
}
