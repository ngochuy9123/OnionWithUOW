using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		protected readonly AppDBContext _dbContext;

		public GenericRepository(AppDBContext dbContext)
		{
			_dbContext = dbContext;
		}

		public void Add(T entity)
		{
			_dbContext.Set<T>().Add(entity);
		}

		public void AddRange(IEnumerable<T> entities)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
		{
			return _dbContext.Set<T>().Where(expression);
		}

		public IEnumerable<T> GetAll()
		{
			return _dbContext.Set<T>().ToList();
		}

		public T GetById(int id)
		{
			return _dbContext.Set<T>().Find(id);
		}

		public void Remove(T entity)
		{
			_dbContext.Set<T>().Remove(entity);
		}

		public void RemoveRange(IEnumerable<T> entities)
		{
			throw new NotImplementedException();
		}

		public void Update(T entity)
		{
			_dbContext.Update(entity);
		}
	}
}
