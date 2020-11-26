﻿// <auto-generated />
using System;
using FMS.Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FMS.Dal.Migrations
{
    [DbContext(typeof(FMSDbContext))]
    partial class FMSDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("FMS.Domain.Models.BusinessLine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("FMS_divkood")
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("BusinessLines");
                });

            modelBuilder.Entity("FMS.Domain.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("FMS_rkood")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("FMS.Domain.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeliveryTermText")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FMS_ykood")
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<int?>("FMS_yksusid")
                        .HasColumnType("int");

                    b.Property<int>("FixedDiscountPercent")
                        .HasColumnType("int");

                    b.Property<bool>("IsVAT")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<int>("PaymentTermId")
                        .HasColumnType("int");

                    b.Property<string>("RegNo")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("VATNo")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("PaymentTermId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("FMS.Domain.Models.CustomerAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("County")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsBilling")
                        .HasColumnType("bit");

                    b.Property<string>("PostCode")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("CustomerId");

                    b.ToTable("CustomerAddresses");
                });

            modelBuilder.Entity("FMS.Domain.Models.CustomerContact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Job")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Mobile")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("CustomerContacts");
                });

            modelBuilder.Entity("FMS.Domain.Models.DeliveryTerm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("DeliveryTerms");
                });

            modelBuilder.Entity("FMS.Domain.Models.PaymentTerm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("PaymentDays")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PaymentTerms");
                });

            modelBuilder.Entity("FMS.Domain.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("FMS_suurus")
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("FMS_tkood")
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ProductBaseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductBaseId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("FMS.Domain.Models.ProductBase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("BusinessLineId")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("FMS_lsuurus")
                        .HasColumnType("bit");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NameEng")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NameGer")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("ProductBrandId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductCollectionId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductDesignId")
                        .HasColumnType("int");

                    b.Property<int>("ProductDestinationTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductGroupId")
                        .HasColumnType("int");

                    b.Property<int>("ProductMaterialId")
                        .HasColumnType("int");

                    b.Property<int>("ProductSourceTypeId")
                        .HasColumnType("int");

                    b.Property<int>("ProductStatusId")
                        .HasColumnType("int");

                    b.Property<int>("ProductTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BusinessLineId");

                    b.HasIndex("ProductBrandId");

                    b.HasIndex("ProductCollectionId");

                    b.HasIndex("ProductDesignId");

                    b.HasIndex("ProductDestinationTypeId");

                    b.HasIndex("ProductGroupId");

                    b.HasIndex("ProductMaterialId");

                    b.HasIndex("ProductSourceTypeId");

                    b.HasIndex("ProductStatusId");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("ProductBases");
                });

            modelBuilder.Entity("FMS.Domain.Models.ProductBaseProductVariant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("ProductBaseId")
                        .HasColumnType("int");

                    b.Property<int>("ProductVariantTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductBaseId", "ProductVariantTypeId");

                    b.ToTable("ProductBaseProductVariants");
                });

            modelBuilder.Entity("FMS.Domain.Models.ProductBaseProductVariantType", b =>
                {
                    b.Property<int>("ProductBaseId")
                        .HasColumnType("int");

                    b.Property<int>("ProductVariantTypeId")
                        .HasColumnType("int");

                    b.HasKey("ProductBaseId", "ProductVariantTypeId");

                    b.HasIndex("ProductVariantTypeId");

                    b.ToTable("ProductBaseProductVariantTypes");
                });

            modelBuilder.Entity("FMS.Domain.Models.ProductBrand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("FMS_suurustype2")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("ProductBrands");
                });

            modelBuilder.Entity("FMS.Domain.Models.ProductCollection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("FMS_lamudel")
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("ProductBrandId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductBrandId");

                    b.ToTable("ProductCollections");
                });

            modelBuilder.Entity("FMS.Domain.Models.ProductDesign", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("ProductCollectionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductCollectionId");

                    b.ToTable("ProductDesigns");
                });

            modelBuilder.Entity("FMS.Domain.Models.ProductDestinationType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("FMS_ttyyp")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("ProductDestinationTypes");
                });

            modelBuilder.Entity("FMS.Domain.Models.ProductGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("FMS_agrupp")
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("FMS_aliik")
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("ProductTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("ProductGroups");
                });

            modelBuilder.Entity("FMS.Domain.Models.ProductMaterial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("FMS_pmat")
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("ProductMaterials");
                });

            modelBuilder.Entity("FMS.Domain.Models.ProductProductVariant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ProductBaseProductVariantId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductBaseProductVariantId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductProductVariants");
                });

            modelBuilder.Entity("FMS.Domain.Models.ProductSourceType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("FMS_akat")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("ProductSourceTypes");
                });

            modelBuilder.Entity("FMS.Domain.Models.ProductStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("FMS_aolek")
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("ProductStatuses");
                });

            modelBuilder.Entity("FMS.Domain.Models.ProductType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("FMS_aliik")
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("ProductTypes");
                });

            modelBuilder.Entity("FMS.Domain.Models.ProductVariantType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("HasStandardVariants")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("ProductVariantTypes");
                });

            modelBuilder.Entity("FMS.Domain.Models.StandardProductVariant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("ProductVariantTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductVariantTypeId");

                    b.ToTable("StandardProductVariants");
                });

            modelBuilder.Entity("FMS.Domain.Models.Customer", b =>
                {
                    b.HasOne("FMS.Domain.Models.PaymentTerm", "PaymentTerm")
                        .WithMany()
                        .HasForeignKey("PaymentTermId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PaymentTerm");
                });

            modelBuilder.Entity("FMS.Domain.Models.CustomerAddress", b =>
                {
                    b.HasOne("FMS.Domain.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FMS.Domain.Models.Customer", "Customer")
                        .WithMany("Addresses")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("FMS.Domain.Models.CustomerContact", b =>
                {
                    b.HasOne("FMS.Domain.Models.Customer", "Customer")
                        .WithMany("Contacts")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("FMS.Domain.Models.Product", b =>
                {
                    b.HasOne("FMS.Domain.Models.ProductBase", "ProductBase")
                        .WithMany("Products")
                        .HasForeignKey("ProductBaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductBase");
                });

            modelBuilder.Entity("FMS.Domain.Models.ProductBase", b =>
                {
                    b.HasOne("FMS.Domain.Models.BusinessLine", "BusinessLine")
                        .WithMany()
                        .HasForeignKey("BusinessLineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FMS.Domain.Models.ProductBrand", "ProductBrand")
                        .WithMany()
                        .HasForeignKey("ProductBrandId");

                    b.HasOne("FMS.Domain.Models.ProductCollection", "ProductCollection")
                        .WithMany()
                        .HasForeignKey("ProductCollectionId");

                    b.HasOne("FMS.Domain.Models.ProductDesign", "ProductDesign")
                        .WithMany()
                        .HasForeignKey("ProductDesignId");

                    b.HasOne("FMS.Domain.Models.ProductDestinationType", "ProductDestinationType")
                        .WithMany()
                        .HasForeignKey("ProductDestinationTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FMS.Domain.Models.ProductGroup", "ProductGroup")
                        .WithMany()
                        .HasForeignKey("ProductGroupId");

                    b.HasOne("FMS.Domain.Models.ProductMaterial", "ProductMaterial")
                        .WithMany()
                        .HasForeignKey("ProductMaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FMS.Domain.Models.ProductSourceType", "ProductSourceType")
                        .WithMany()
                        .HasForeignKey("ProductSourceTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FMS.Domain.Models.ProductStatus", "ProductStatus")
                        .WithMany()
                        .HasForeignKey("ProductStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FMS.Domain.Models.ProductType", "ProductType")
                        .WithMany()
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BusinessLine");

                    b.Navigation("ProductBrand");

                    b.Navigation("ProductCollection");

                    b.Navigation("ProductDesign");

                    b.Navigation("ProductDestinationType");

                    b.Navigation("ProductGroup");

                    b.Navigation("ProductMaterial");

                    b.Navigation("ProductSourceType");

                    b.Navigation("ProductStatus");

                    b.Navigation("ProductType");
                });

            modelBuilder.Entity("FMS.Domain.Models.ProductBaseProductVariant", b =>
                {
                    b.HasOne("FMS.Domain.Models.ProductBaseProductVariantType", null)
                        .WithMany("ProductBaseProductVariants")
                        .HasForeignKey("ProductBaseId", "ProductVariantTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FMS.Domain.Models.ProductBaseProductVariantType", b =>
                {
                    b.HasOne("FMS.Domain.Models.ProductVariantType", "ProductVariantType")
                        .WithMany()
                        .HasForeignKey("ProductVariantTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductVariantType");
                });

            modelBuilder.Entity("FMS.Domain.Models.ProductCollection", b =>
                {
                    b.HasOne("FMS.Domain.Models.ProductBrand", "ProductBrand")
                        .WithMany()
                        .HasForeignKey("ProductBrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductBrand");
                });

            modelBuilder.Entity("FMS.Domain.Models.ProductDesign", b =>
                {
                    b.HasOne("FMS.Domain.Models.ProductCollection", "ProductCollection")
                        .WithMany()
                        .HasForeignKey("ProductCollectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductCollection");
                });

            modelBuilder.Entity("FMS.Domain.Models.ProductGroup", b =>
                {
                    b.HasOne("FMS.Domain.Models.ProductType", "ProductType")
                        .WithMany()
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductType");
                });

            modelBuilder.Entity("FMS.Domain.Models.ProductProductVariant", b =>
                {
                    b.HasOne("FMS.Domain.Models.ProductBaseProductVariant", "ProductBaseProductVariant")
                        .WithMany()
                        .HasForeignKey("ProductBaseProductVariantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FMS.Domain.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("ProductBaseProductVariant");
                });

            modelBuilder.Entity("FMS.Domain.Models.StandardProductVariant", b =>
                {
                    b.HasOne("FMS.Domain.Models.ProductVariantType", "ProductVariantType")
                        .WithMany()
                        .HasForeignKey("ProductVariantTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductVariantType");
                });

            modelBuilder.Entity("FMS.Domain.Models.Customer", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Contacts");
                });

            modelBuilder.Entity("FMS.Domain.Models.ProductBase", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("FMS.Domain.Models.ProductBaseProductVariantType", b =>
                {
                    b.Navigation("ProductBaseProductVariants");
                });
#pragma warning restore 612, 618
        }
    }
}
