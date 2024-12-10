using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
	public interface IUnitOfWork : IDisposable
	{
		IUserRepository Users { get; }
		IBookRepository Books { get; }
		ICartRepository Carts { get; }
		ICatalogueRepository Catalogues { get; }
		ICartDetailRepository CartDetail { get; }
		IBookCatalogueRepository BookCatalogue { get; }
		int Complete();
	}
}
