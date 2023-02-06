#nullable disable

namespace Catalog.Infrastructure.Migrations
{
    [DbContext(typeof(CatalogContext))]
    [Migration("20230201072817_init")]
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

            modelBuilder.Entity("Catalog.Domain.AggregatesModel.CatalogAggregate.CatalogItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AvailableStock")
                        .HasColumnType("integer")
                        .HasColumnName("AvailableStock");

                    b.Property<Guid>("CatalogTypeId")
                        .HasColumnType("uuid")
                        .HasColumnName("CatalogTypeId");

                    b.Property<int>("MaxStockThreshold")
                        .HasColumnType("integer")
                        .HasColumnName("MaxStockThreshold");

                    b.Property<int>("MinStockThreshold")
                        .HasColumnType("integer")
                        .HasColumnName("MinStockThreshold");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("Name");

                    b.Property<int>("Price")
                        .HasColumnType("integer")
                        .HasColumnName("Price");

                    b.HasKey("Id");

                    b.HasIndex("CatalogTypeId");

                    b.ToTable("Catalog", "Catalog");
                });

            modelBuilder.Entity("Catalog.Domain.AggregatesModel.CatalogTypeAggregate.CatalogType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("Type");

                    b.HasKey("Id");

                    b.ToTable("CatalogType", "Catalog");
                });

            modelBuilder.Entity("Catalog.Domain.AggregatesModel.SupplierAggregate.Supplier", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CatalogTypeId")
                        .HasColumnType("uuid")
                        .HasColumnName("CatalogTypeId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.HasIndex("CatalogTypeId");

                    b.ToTable("Supplier", "Catalog");
                });

            modelBuilder.Entity("Catalog.Domain.AggregatesModel.SupplierAggregate.SupplierItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("RequestNumber")
                        .HasColumnType("integer")
                        .HasColumnName("RequestNumber");

                    b.Property<Guid>("SupplierId")
                        .HasColumnType("uuid")
                        .HasColumnName("SupplierId");

                    b.HasKey("Id");

                    b.HasIndex("SupplierId");

                    b.ToTable("SupplierItem", "Catalog");
                });

            modelBuilder.Entity("Catalog.Domain.AggregatesModel.CatalogAggregate.CatalogItem", b =>
                {
                    b.HasOne("Catalog.Domain.AggregatesModel.CatalogTypeAggregate.CatalogType", null)
                        .WithMany()
                        .HasForeignKey("CatalogTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Catalog.Domain.AggregatesModel.SupplierAggregate.Supplier", b =>
                {
                    b.HasOne("Catalog.Domain.AggregatesModel.CatalogTypeAggregate.CatalogType", null)
                        .WithMany()
                        .HasForeignKey("CatalogTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Catalog.Domain.AggregatesModel.SupplierAggregate.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("SupplierId")
                                .HasColumnType("uuid");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("SupplierId");

                            b1.ToTable("Supplier", "Catalog");

                            b1.WithOwner()
                                .HasForeignKey("SupplierId");
                        });

                    b.Navigation("Address")
                        .IsRequired();
                });

            modelBuilder.Entity("Catalog.Domain.AggregatesModel.SupplierAggregate.SupplierItem", b =>
                {
                    b.HasOne("Catalog.Domain.AggregatesModel.SupplierAggregate.Supplier", null)
                        .WithMany("SupplierItems")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Catalog.Domain.AggregatesModel.SupplierAggregate.Supplier", b =>
                {
                    b.Navigation("SupplierItems");
                });
#pragma warning restore 612, 618
        }
    }
}
