using MenuQR.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MenuQR.Infra.Data.Mapping
{
    internal class OrderProductMap : IEntityTypeConfiguration<OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            builder.ToTable("OrderProduct");

            builder.HasKey(prop => new { prop.OrderId, prop.ProductId });

            builder.Property(prop => prop.OrderId)
               .IsRequired()
               .HasColumnName("OrderId")
               .HasColumnType("int");

            builder.Property(prop => prop.ProductId)
               .IsRequired()
               .HasColumnName("ProductId")
               .HasColumnType("int");

            builder.HasOne(e => e.Order)
                .WithMany(e => e.OrderProducts)
                .HasForeignKey(e => e.OrderId)
                .IsRequired();

            builder.HasOne(e => e.Product)
                .WithMany(e => e.OrderProducts)
                .HasForeignKey(e => e.ProductId)
                .IsRequired();


        }
    }
}
