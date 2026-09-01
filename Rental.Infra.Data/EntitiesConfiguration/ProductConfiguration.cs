using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental.Infra.Data.EntitiesConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
           builder.HasKey(p => p.Id);

              builder.Property(p => p.Name)
                 .IsRequired()
                 .HasMaxLength(100);

             builder.Property(p => p.Description)
                  .IsRequired()
                 .HasMaxLength(500);

             builder.Property(p => p.Price)
                 .IsRequired()
                 .HasColumnType("decimal(10,2)");

            builder.Property(p => p.Quantity)
                   .IsRequired();

            builder.Property(p => p.ImageUrl)
                   .HasMaxLength(500)
                   .IsRequired();

            builder.Property(p => p.Available)
                   .IsRequired()
                   .HasDefaultValue(true);

            builder.Property(p => p.CategoryId)
                 .IsRequired();     

             builder.HasOne(p => p.Category)         
                 .WithMany(c => c.Products)
                 .HasForeignKey(p => p.CategoryId)
                 .IsRequired();
        }
    }
}
