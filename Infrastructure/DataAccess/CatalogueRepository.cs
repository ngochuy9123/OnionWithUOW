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
	public class CatalogueRepository :  GenericRepository<Catalogue>, ICatalogueRepository
	{
		public CatalogueRepository(AppDBContext dbContext) : base(dbContext)
		{
		}
	}
}
