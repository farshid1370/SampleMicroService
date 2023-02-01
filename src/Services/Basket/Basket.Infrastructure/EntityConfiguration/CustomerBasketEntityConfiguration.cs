namespace Basket.Infrastructure.EntityConfiguration;

public class CustomerBasketEntityConfiguration : IEntityTypeConfiguration<CustomerBasket>
{
    public void Configure(EntityTypeBuilder<CustomerBasket> builder)
    {
        builder.ToTable("CustomerBasket", schema: "Basket");
        builder.HasKey(b => b.Id);
        builder.Ignore(b => b.DomainEvents);
        builder.Ignore(b => b.Items);
        var basketItemsNavigation = builder.Metadata.FindNavigation(nameof(CustomerBasket.Items));
        basketItemsNavigation?.SetPropertyAccessMode(PropertyAccessMode.Field);
        builder.Property(b=>b.BuyerId).HasField("_buyerId").HasColumnName("BuyerId").UsePropertyAccessMode(PropertyAccessMode.Field).IsRequired();
    }
}