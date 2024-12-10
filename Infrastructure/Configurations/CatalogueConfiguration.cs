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
	public class CatalogueConfiguration : IEntityTypeConfiguration<Catalogue>
	{
		public void Configure(EntityTypeBuilder<Catalogue> builder)
		{
			builder.ToTable("Catalogue", "book");
			builder.Property(c => c.CatalogueId).IsRequired();

		}
	}
}
