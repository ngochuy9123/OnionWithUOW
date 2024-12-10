using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class Book
	{
		[Key]
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public int Price { get; set; }
		public int DiscountPrice { get; set; }
		public string Author { get; set; }
		public DateTime PublishDate { get; set; }

		public ICollection<CartDetail> CartDetails { get; set; }
		[JsonIgnore]
		public ICollection<BookCatalogue> BookCatalogues { get; set; }
	}
}
