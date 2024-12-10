using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataAccess
{
	public class BookCatalogueRepository : GenericRepository<BookCatalogue>, IBookCatalogueRepository
	{
		public BookCatalogueRepository(AppDBContext dbContext) : base(dbContext)
		{
		}
	}
}
