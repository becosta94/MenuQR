using OrderQR.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OrderQR.Infra.Data.Mapping
{
    public class AuditMap : IEntityTypeConfiguration<Audit>
    {
        public void Configure(EntityTypeBuilder<Audit> builder)
        {
            builder.HasKey(e => e.Id);
            builder.ToTable("AuditLogs");

            builder.Property(p => p.UserId).HasColumnType("varchar(MAX)");
            builder.Property(p => p.Type).HasColumnType("varchar(MAX)");
            builder.Property(p => p.TableName).HasColumnType("varchar(MAX)");
            builder.Property(p => p.OldValues).HasColumnType("varchar(MAX)");
            builder.Property(p => p.NewValues).HasColumnType("varchar(MAX)");
            builder.Property(p => p.AffectedColumns).HasColumnType("varchar(MAX)");
            builder.Property(p => p.PrimaryKey).HasColumnType("varchar(MAX)");
        }
    }
}
