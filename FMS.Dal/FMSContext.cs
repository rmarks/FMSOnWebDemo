﻿using FMS.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FMS.Dal
{
    public class FMSContext : DbContext
    {
        public FMSContext(DbContextOptions<FMSContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public DbSet<CustomerContact> CustomerContacts { get; set; }
        public DbSet<DeliveryTerm> DeliveryTerms { get; set; }
        public DbSet<Country> Countries { get; set; }

        public DbSet<ProductBase> ProductBases { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductStatus> ProductStatuses { get; set; }
        public DbSet<BusinessLine> BusinessLines { get; set; }
        public DbSet<ProductSourceType> ProductSourceTypes { get; set; }
        public DbSet<ProductDestinationType> ProductDestinationTypes { get; set; }
        public DbSet<ProductMaterial> ProductMaterials { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductGroup> ProductGroups { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductCollection> ProductCollections { get; set; }
        public DbSet<ProductDesign> ProductDesigns { get; set; }

        public DbSet<ProductVariantType> ProductVariantTypes { get; set; }
        public DbSet<StandardProductVariant> StandardProductVariants { get; set; }
        public DbSet<ProductBaseProductVariantType> ProductBaseProductVariantTypes { get; set; }
        public DbSet<ProductBaseProductVariant> ProductBaseProductVariants { get; set; }
        public DbSet<ProductProductVariant> ProductProductVariants { get; set; }

        public DbSet<Location> Locations { get; set; }
        public DbSet<LocationType> LocationTypes { get; set; }
        public DbSet<Inventory> Inventory { get; set; }

        public DbSet<OrderType> OrderTypes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }

        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentLine> DocumentLines { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductBaseProductVariantType>()
                .HasKey(p => new { p.ProductBaseId, p.ProductVariantTypeId });

            modelBuilder.Entity<ProductBaseProductVariant>()
                .HasOne<ProductBaseProductVariantType>()
                .WithMany("ProductBaseProductVariants")
                .HasForeignKey(pv => new { pv.ProductBaseId, pv.ProductVariantTypeId });

            modelBuilder.Entity<Document>()
                .HasOne<Location>(d => d.Location)
                .WithMany()
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
