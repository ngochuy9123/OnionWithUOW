﻿using Domain.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
	public interface IBookRepository : IGenericRepository<Book>
	{
		public IEnumerable<BookWithCatalogueDTO> GetBooksWithFullInfoAndCatalogueNames();
	}
}
