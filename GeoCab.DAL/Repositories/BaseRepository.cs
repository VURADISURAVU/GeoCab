using System.Collections.Generic;
using System.Linq;
using GeoCab.DAL.DataContext;
using GeoCab.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace GeoCab.DAL.Repositories
{
	public abstract class BaseRepository<T> where T : BaseModel
	{
		protected GeoCabDbContext _dbContext;
		protected DbSet<T> _dbSet;

		public BaseRepository(GeoCabDbContext dbContext)
		{
			_dbContext = dbContext;
			_dbSet = _dbContext.Set<T>();
		}
		
		public T Save(T model)
		{
			_dbSet.Add(model);
			_dbContext.SaveChanges();

			return model;
		}

		public T GetById(int id)
		{
			return _dbSet.SingleOrDefault(x => x.Id == id);
		}
		
		public List<T> GetAll()
		{
			return _dbSet.ToList();
		}

		public void Remove(T model)
		{
			_dbSet.Remove(model);
			_dbContext.SaveChanges();
		}
	}
}