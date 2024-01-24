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
               .HasColumnType("int")
               .UseIdentityColumn();

            builder.Property(prop => prop.ProductId)
               .IsRequired()
               .HasColumnName("ProductId")
               .HasColumnType("int");

            builder.Property(prop => prop.Amount)
               .IsRequired()
               .HasColumnName("Amount")
               .HasColumnType("int");

            builder.Property(prop => prop.Total)
               .IsRequired()
               .HasColumnName("Total")
               .HasColumnType("float");

            builder.HasOne(prop => prop.Order)
                .WithMany(prop => prop.OrderProducts)
                .HasForeignKey(prop => prop.OrderId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(prop => prop.Product)
                .WithMany(prop => prop.OrderProducts)
                .HasForeignKey(prop => prop.ProductId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
