using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataAccess
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly AppDBContext _dbContext;
		public IUserRepository Users { get; private set; }
		public IBookRepository Books { get; private set; }
		public ICartRepository Carts { get; private set; }
		public ICatalogueRepository	Catalogues { get; private set; }
		public ICartDetailRepository CartDetail { get; private set; }
		public IBookCatalogueRepository	BookCatalogue { get; private set; }

		public UnitOfWork(AppDBContext dbContext, IUserRepository users, IBookRepository books, ICartRepository carts, ICatalogueRepository catalogues, ICartDetailRepository cartDetail, IBookCatalogueRepository bookCatalogue)
		{
			_dbContext = dbContext;
			Users = users;
			Books = books;
			Carts = carts;
			Catalogues = catalogues;
			CartDetail = cartDetail;
			BookCatalogue = bookCatalogue;
		}

		public int Complete()
		{
			return _dbContext.SaveChanges();
		}

		public void Dispose()
		{
			_dbContext.Dispose();
		}
	}
}
