namespace Catalog.Infrastructure.EntityConfigurations;

public class SupplierItemEntityConfiguration:IEntityTypeConfiguration<SupplierItem>
{
    public void Configure(EntityTypeBuilder<SupplierItem> builder)
    {
        builder.ToTable("SupplierItem", schema: "Catalog");
        builder.HasKey(s => s.Id);
        builder.Ignore(s => s.DomainEvents);
        builder.Property(s => s.RequestNumber).HasField("_requestNumber").HasColumnName("RequestNumber").UsePropertyAccessMode(PropertyAccessMode.Field).IsRequired();
        builder.Property(s => s.SupplierId).HasField("_supplierId").HasColumnName("SupplierId").UsePropertyAccessMode(PropertyAccessMode.Field).IsRequired();
        builder.HasOne<Supplier>().WithMany(s => s.SupplierItems).HasForeignKey(s=>s.SupplierId);
    }
}