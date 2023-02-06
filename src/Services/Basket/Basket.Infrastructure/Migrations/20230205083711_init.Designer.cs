#nullable disable

namespace Basket.Infrastructure.Migrations
{
    [DbContext(typeof(BasketContext))]
    [Migration("20230205083711_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Basket.Domain.AggregatesModel.BasketAggregate.BasketItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CustomerBasketId")
                        .HasColumnType("uuid")
                        .HasColumnName("CustomerBasketId");

                    b.Property<decimal>("OldUnitPrice")
                        .HasColumnType("numeric")
                        .HasColumnName("OldUnitPrice");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid")
                        .HasColumnName("ProductId");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("ProductName");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer")
                        .HasColumnName("Quantity");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("numeric")
                        .HasColumnName("UnitPrice");

                    b.HasKey("Id");

                    b.HasIndex("CustomerBasketId");

                    b.ToTable("BasketItems", "Basket");
                });

            modelBuilder.Entity("Basket.Domain.AggregatesModel.BasketAggregate.CustomerBasket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("BuyerId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("BuyerId");

                    b.HasKey("Id");

                    b.ToTable("CustomerBasket", "Basket");
                });

            modelBuilder.Entity("Basket.Domain.AggregatesModel.BasketAggregate.BasketItem", b =>
                {
                    b.HasOne("Basket.Domain.AggregatesModel.BasketAggregate.CustomerBasket", null)
                        .WithMany("BasketItems")
                        .HasForeignKey("CustomerBasketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Basket.Domain.AggregatesModel.BasketAggregate.CustomerBasket", b =>
                {
                    b.Navigation("BasketItems");
                });
#pragma warning restore 612, 618
        }
    }
}
