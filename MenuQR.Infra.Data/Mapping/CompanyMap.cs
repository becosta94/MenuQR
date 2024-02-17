using MenuQR.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MenuQR.Infra.Data.Mapping
{
    public class CompanyMap : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Company");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Name)
               .IsRequired()
               .HasColumnName("Name")
               .HasColumnType("varchar(250)");
            
            builder.Property(prop => prop.Adress)
                   .IsRequired()
                   .HasColumnName("Adress")
                   .HasColumnType("varchar(250)");      
            
            builder.Property(prop => prop.ResponsibleName)
                   .IsRequired()
                   .HasColumnName("Adress")
                   .HasColumnType("varchar(250)");
                        
            builder.Property(prop => prop.DocumentNumber)
                   .IsRequired()
                   .HasColumnName("DocumentNumber")
                   .HasColumnType("varchar(50)");
                                    
            builder.Property(prop => prop.Phone)
                   .IsRequired()
                   .HasColumnName("Phone")
                   .HasColumnType("varchar(50)");

            builder.HasIndex(prop => prop.Name)
                .HasDatabaseName("IX_Company_Name");

            builder.HasData(new Company() { Id = 1, Name = "Bar do Bê", CompanyId = 1, Adress = "Rua Três Fazendas 370", Phone = "31987942350" });
        }
    }
}
