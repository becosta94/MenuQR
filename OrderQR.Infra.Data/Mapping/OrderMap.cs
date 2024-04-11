using OrderQR.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OrderQR.Infra.Data.Mapping
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");

            builder.HasKey(prop => new { prop.Id, prop.CompanyId });

            builder.Property(prop => prop.Id)
                    .ValueGeneratedOnAdd()
                    .UseIdentityColumn();

            builder.Property(prop => prop.CompanyId)
               .IsRequired()
               .HasColumnName("CompanyId")
               .HasColumnType("int");

            builder.Property(prop => prop.Deliverd)
               .IsRequired()
               .HasColumnName("Deliverd")
               .HasColumnType("bit");

            builder.Property(prop => prop.CreatedAt)
               .IsRequired()
               .HasColumnName("CreatedAt")
               .HasColumnType("datetime2");            
            
            builder.Property(prop => prop.DeliveryTime)
               .HasColumnName("DeliveryTime")
               .HasColumnType("datetime2");

            builder.HasOne(prop => prop.CustomerHistory)
                .WithMany(prop => prop.Orders)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(prop => prop.Customer)
                .WithMany()
                .HasForeignKey(prop => prop.CustomerDocument)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(prop => prop.Table)
                .WithMany()
                .HasForeignKey(prop => new { prop.TableId, prop.CompanyId })
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(prop => prop.CompanyId)
                .HasDatabaseName("IX_Order_Company");

        }
    }
}
