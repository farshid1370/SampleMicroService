namespace Catalog.Infrastructure.EntityConfigurations;

public class CatalogEntityConfiguration:IEntityTypeConfiguration<CatalogItem>
{
    public void Configure(EntityTypeBuilder<CatalogItem> builder)
    {
        builder.ToTable("Catalog", schema: "Catalog");
        builder.HasKey(c => c.Id);
        builder.Ignore(c => c.DomainEvents);
        builder.Property(c => c.Name).HasField("_name").HasColumnName("Name").UsePropertyAccessMode(PropertyAccessMode.Field).IsRequired().HasMaxLength(50);
        builder.Property(c => c.Price).HasField("_price").HasColumnName("Price").UsePropertyAccessMode(PropertyAccessMode.Field).IsRequired();
        builder.Property(c => c.AvailableStock).HasField("_availableStock").HasColumnName("AvailableStock").UsePropertyAccessMode(PropertyAccessMode.Field).IsRequired();
        builder.Property(c => c.MinStockThreshold).HasField("_minStockThreshold").HasColumnName("MinStockThreshold").UsePropertyAccessMode(PropertyAccessMode.Field).IsRequired();
        builder.Property(c => c.MaxStockThreshold).HasField("_maxStockThreshold").HasColumnName("MaxStockThreshold").UsePropertyAccessMode(PropertyAccessMode.Field).IsRequired();
        builder.Property(c => c.CatalogTypeId).HasField("_catalogTypeId").HasColumnName("CatalogTypeId").UsePropertyAccessMode(PropertyAccessMode.Field).IsRequired();
        builder.HasOne<CatalogType>().WithMany().HasForeignKey(c=>c.CatalogTypeId);

    }
}