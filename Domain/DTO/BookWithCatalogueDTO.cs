using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
	public class BookWithCatalogueDTO
	{
		public Book Book { get; set; } // Toàn bộ thông tin cuốn sách
		public List<string> CatalogueNames { get; set; } // Danh sách tên danh mục
	}
}
