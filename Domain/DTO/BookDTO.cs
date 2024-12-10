using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
	public class BookDTO
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public int Price { get; set; }
		public int DiscountPrice { get; set; }
		public string Author { get; set; }
		public DateTime PublishDate { get; set; }
		//
		public List<string> CatalogueNames { get; set; }
	}
}
