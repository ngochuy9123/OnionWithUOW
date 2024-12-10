using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
	public class CartDetailConfiguration : IEntityTypeConfiguration<CartDetail>
	{

		public void Configure(EntityTypeBuilder<CartDetail> builder)
		{
			builder.ToTable("CartDetail", "book");
			builder.Property(s => s.CartId).IsRequired();
			builder.Property(s => s.BookId).IsRequired();
		}
	}
}
