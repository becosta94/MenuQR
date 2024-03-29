using Microsoft.EntityFrameworkCore;
using MenuQR.Domain.Entities;
using MenuQR.Infra.Data.Mapping;
using Microsoft.AspNetCore.Identity;

namespace MenuQR.Infra.Data.Context
{
    public class SqlContext : DbContext
    {
        public virtual DbSet<Bill>  Bills { get; set; }
        public virtual DbSet<BillClosureOrder> BillClosureOrders { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerHistory> CustomerHistories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderProduct> OrderProducts { get; set; }
        public virtual DbSet<Table> Tables { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductType> ProductsType { get; set; }
        public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new BillMap());
            modelBuilder.ApplyConfiguration(new BillClosureOrderMap());
            modelBuilder.ApplyConfiguration(new CompanyMap());
            modelBuilder.ApplyConfiguration(new CustomerHistoryMap());
            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new OrderMap());
            modelBuilder.ApplyConfiguration(new OrderProductMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new ProductTypeMap());
            modelBuilder.ApplyConfiguration(new TableMap());
        }
    }
}
