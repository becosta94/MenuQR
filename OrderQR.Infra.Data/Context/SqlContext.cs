using OrderQR.Domain;
using OrderQR.Domain.Entities;
using OrderQR.Infra.Data.Mapping;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Security.Claims;

namespace OrderQR.Infra.Data.Context
{
    public class SqlContext : DbContext
    {
        public IHttpContextAccessor HttpContext { get; }
        public virtual DbSet<Audit> Audits { get; set; }
        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<BillClosureOrder> BillClosureOrders { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerHistory> CustomerHistories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderProduct> OrderProducts { get; set; }
        public virtual DbSet<Table> Tables { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductOffList> ProductsOffList { get; set; }
        public virtual DbSet<ProductType> ProductsType { get; set; }
        public SqlContext(DbContextOptions<SqlContext> options, IHttpContextAccessor httpContext) : base(options)
        {
            HttpContext = httpContext;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AuditMap());
            modelBuilder.ApplyConfiguration(new BillMap());
            modelBuilder.ApplyConfiguration(new BillClosureOrderMap());
            modelBuilder.ApplyConfiguration(new CompanyMap());
            modelBuilder.ApplyConfiguration(new CustomerHistoryMap());
            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new OrderMap());
            modelBuilder.ApplyConfiguration(new OrderProductMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new ProductOffListMap());
            modelBuilder.ApplyConfiguration(new ProductTypeMap());
            modelBuilder.ApplyConfiguration(new TableMap());
        }
        public override int SaveChanges()
        {
            BeforeSaveChanges().ConfigureAwait(false).GetAwaiter().GetResult();
            var result = base.SaveChanges();
            return result;
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await BeforeSaveChanges();
            var result = await base.SaveChangesAsync(cancellationToken);
            return result;
        }

        private async Task BeforeSaveChanges()
        {
            try
            {
                var login = HttpContext?.HttpContext?.User?.FindFirst(ClaimTypes.Email)?.Value;
                ChangeTracker.DetectChanges();
                List<EntityEntry> a = new List<EntityEntry>(ChangeTracker.Entries());

                foreach (var entry in a)
                {
                    if (entry.Entity is BaseEntity auditable)
                    {
                        auditable.UpdateDate(entry.State);
                    }

                    if (entry.Entity is Audit || entry.State is EntityState.Detached or EntityState.Unchanged)
                        continue;

                    var auditEntry = new AuditEntry(entry) { TableName = entry.Entity.GetType().Name, UserId = "Teste" };

                    foreach (var property in entry.Properties)
                    {
                        var propertyName = property.Metadata.Name;
                        if (property.Metadata.IsPrimaryKey())
                        {
                            auditEntry.KeyValues[propertyName] = property.CurrentValue;
                            continue;
                        }

                        switch (entry.State)
                        {
                            case EntityState.Added:
                                auditEntry.AuditType = AuditType.Create;
                                auditEntry.NewValues[propertyName] = property.CurrentValue;
                                break;
                            case EntityState.Deleted:
                                auditEntry.AuditType = AuditType.Delete;
                                auditEntry.OldValues[propertyName] = property.OriginalValue;
                                break;
                            case EntityState.Modified:
                                if ((property.OriginalValue != null && property.CurrentValue != null && property.OriginalValue.ToString() != property.CurrentValue.ToString()) ||
                                    (property.OriginalValue == null && property.CurrentValue != null) ||
                                    (property.OriginalValue != null && property.CurrentValue == null))
                                {
                                    auditEntry.ChangedColumns.Add(propertyName);
                                    auditEntry.AuditType = AuditType.Update;
                                    auditEntry.OldValues[propertyName] = property.OriginalValue;
                                    auditEntry.NewValues[propertyName] = property.CurrentValue;
                                }
                                break;
                        }
                    }
                    await Audits.AddAsync(auditEntry.ToAudit());
                }
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex, "Error saving audit");
            }
        }
    }
}
