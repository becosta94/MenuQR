using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace OrderQR.Domain.Entities
{
    public abstract class BaseEntity
    {
        public virtual int Id { get; set; }
        public virtual DateTime? CreatedAt { get; set; }
        public virtual DateTime? UpdatedAt { get; set; }
        public void UpdateDate(EntityState state)
        {
            switch (state)
            {
                case EntityState.Added:
                case EntityState.Detached:
                    CreatedAt = DateTime.Now;

                    break;
                case EntityState.Modified:
                    UpdatedAt = DateTime.Now;

                    break;
            }
        }
    }
}
