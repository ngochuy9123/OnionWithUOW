using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class CartDetail
	{
		public int Id { get; set; }
		public int CartId { get; set; }
		public int BookId { get; set; }
		public int Quantity { get; set; }
		public int Price { get; set; }

		[ForeignKey(nameof(CartId))]
		public Cart Cart { get; set; }

		[ForeignKey(nameof(BookId))]
		public Book Book { get; set; }
	}
}
