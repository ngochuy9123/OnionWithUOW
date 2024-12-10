using Domain.DTO;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataAccess
{
	public class BookRepository : GenericRepository<Book>, IBookRepository
	{
		public BookRepository(AppDBContext dbContext) : base(dbContext)
		{
		}

		public IEnumerable<BookWithCatalogueDTO> GetBooksWithFullInfoAndCatalogueNames()
		{
			var result = from bc in _dbContext.BookCatalogue
						 join b in _dbContext.Books on bc.BookId equals b.Id
						 join c in _dbContext.Catalogue on bc.CatalogueId equals c.CatalogueId
						 group c.Name by b into grouped
						 select new BookWithCatalogueDTO
						 {
							 Book = grouped.Key, // Toàn bộ thông tin sách
							 CatalogueNames = grouped.ToList() // Danh sách tên danh mục
						 };

			return result.ToList();
		}


	}
}
