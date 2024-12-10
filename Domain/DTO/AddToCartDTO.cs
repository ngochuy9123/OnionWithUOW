﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
	public class AddToCartDTO
	{
		public int UserId { get; set; }
		public int BookId { get; set; }
		public int Quantity { get; set; } = 1;
	}
}
