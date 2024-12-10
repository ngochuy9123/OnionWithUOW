using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class Cart
	{
		[Key]
		public int Id { get; set; }
		public int UserId { get; set; }
		public DateTime CreatedAt { get; set; }

		[ForeignKey(nameof(UserId))]
		public User User { get; set; }

		public ICollection<CartDetail> CartDetails { get; set; }
	}
}
