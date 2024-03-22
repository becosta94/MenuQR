using MenuQR.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MenuQR.Infra.Data.Mapping
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");


            builder.HasKey(prop => prop.Document);

            builder.Property(prop => prop.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("int")
                .UseIdentityColumn();

            builder.Property(prop => prop.Name)
               .HasColumnName("Name")
               .HasColumnType("varchar(200)");

            }
    }
}
