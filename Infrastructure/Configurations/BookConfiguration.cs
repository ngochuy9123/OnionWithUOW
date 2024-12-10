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
	public class BookConfiguration : IEntityTypeConfiguration<Book>
	{
		public void Configure(EntityTypeBuilder<Book> builder)
		{
			builder.ToTable("Book", "book");
			builder.Property(b => b.Id).IsRequired();
			builder.Property(b => b.Title).HasMaxLength(200).IsRequired();
			builder.Property(b => b.Author).HasMaxLength(200).IsRequired();
		}
	}
}
