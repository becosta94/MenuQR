using Microsoft.EntityFrameworkCore;
using WaiterAI.Domain.Entities;
using WaiterAI.Infra.Data.Mapping;

namespace WaiterAI.Infra.Data.Context
{
    public class SqlContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(new UserMap().Configure);
        }
    }
}
