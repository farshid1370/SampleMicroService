namespace Basket.Infrastructure.EntityConfiguration;

public class BasketItemEntityConfiguration:IEntityTypeConfiguration<BasketItem>
{
    public void Configure(EntityTypeBuilder<BasketItem> builder)
    {
        builder.ToTable("BasketItems", schema: "Basket");
        builder.HasKey(b => b.Id);
        builder.Ignore(b => b.DomainEvents);
        builder.Property(b => b.CustomerBasketId).HasField("_customerBasketId").HasColumnName("CustomerBasketId").UsePropertyAccessMode(PropertyAccessMode.Field).IsRequired();
        builder.Property(b => b.ProductId).HasField("_productId").HasColumnName("ProductId").UsePropertyAccessMode(PropertyAccessMode.Field).IsRequired();
        builder.Property(b => b.ProductName).HasField("_productName").HasColumnName("ProductName").UsePropertyAccessMode(PropertyAccessMode.Field).IsRequired();
        builder.Property(b => b.Quantity).HasField("_quantity").HasColumnName("Quantity").UsePropertyAccessMode(PropertyAccessMode.Field).IsRequired();
        builder.Property(b => b.UnitPrice).HasField("_unitPrice").HasColumnName("UnitPrice").UsePropertyAccessMode(PropertyAccessMode.Field).IsRequired();
        builder.Property(b => b.OldUnitPrice).HasField("_oldUnitPrice").HasColumnName("OldUnitPrice").UsePropertyAccessMode(PropertyAccessMode.Field).IsRequired();
        builder.HasOne<CustomerBasket>().WithMany(b=>b.BasketItems).HasForeignKey(b => b.CustomerBasketId);
    }
}