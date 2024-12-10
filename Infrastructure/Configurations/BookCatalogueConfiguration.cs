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
	public class BookCatalogueConfiguration : IEntityTypeConfiguration<BookCatalogue>
	{
		public void Configure(EntityTypeBuilder<BookCatalogue> builder)
		{
			builder.ToTable("BookCatalogue", "book");
			builder.Property(s => s.BookId).IsRequired();
			builder.Property(s => s.CatalogueId).IsRequired();
		}
	}
}
