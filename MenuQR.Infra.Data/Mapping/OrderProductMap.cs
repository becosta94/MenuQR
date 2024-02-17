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

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Id)
                .UseIdentityColumn();

            builder.Property(prop => prop.OrderId)
               .IsRequired()
               .HasColumnName("OrderId")
               .HasColumnType("int");

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
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(prop => prop.Product)
                .WithMany(prop => prop.OrderProducts)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
