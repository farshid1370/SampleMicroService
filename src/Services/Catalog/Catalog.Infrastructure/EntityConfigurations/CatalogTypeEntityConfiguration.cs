using Catalog.Domain.AggregatesModel.CatalogTypeAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Infrastructure.EntityConfigurations;

public class CatalogTypeEntityConfiguration: IEntityTypeConfiguration<CatalogType>
{
    public void Configure(EntityTypeBuilder<CatalogType> builder)
    {
        builder.ToTable("CatalogType", schema: "Catalog");
        builder.HasKey(c => c.Id);
        builder.Ignore(b => b.DomainEvents);
        builder.Property(c => c.Type).HasField("_type").HasColumnName("Type").UsePropertyAccessMode(PropertyAccessMode.Field).IsRequired().HasMaxLength(100);

    }
}