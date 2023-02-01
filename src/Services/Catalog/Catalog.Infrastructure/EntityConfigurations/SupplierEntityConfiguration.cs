namespace Catalog.Infrastructure.EntityConfigurations;

public class SupplierEntityConfiguration:IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> builder)
    {
        builder.ToTable("Supplier", schema: "Catalog");
        builder.HasKey(s => s.Id);
        builder.Ignore(s => s.DomainEvents);
        builder.Property(s=>s.Name).HasField("_name").HasColumnName("Name").UsePropertyAccessMode(PropertyAccessMode.Field).IsRequired();
        builder.Property(s => s.CatalogTypeId).HasField("_catalogTypeId").HasColumnName("CatalogTypeId").UsePropertyAccessMode(PropertyAccessMode.Field).IsRequired();
        var supplierItemsNavigate = builder.Metadata.FindNavigation(nameof(Supplier.SupplierItems));
        supplierItemsNavigate?.SetPropertyAccessMode(PropertyAccessMode.PreferFieldDuringConstruction);
        builder.OwnsOne(s => s.Address);
        builder.HasOne<CatalogType>().WithMany().HasForeignKey(s => s.CatalogTypeId);

    }
}