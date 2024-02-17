using MenuQR.Domain.Entities;
using MenuQR.Infra.Data.Context;
using MenuQR.Services.Interfaces;

namespace MenuQR.Infra.Data.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly SqlContext _sqlContext;

        public BaseRepository(SqlContext mySqlContext)
        {
            _sqlContext = mySqlContext;
        }

        public void Insert(TEntity obj)
        {
            _sqlContext.Set<TEntity>().Add(obj);
            _sqlContext.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            _sqlContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _sqlContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _sqlContext.Set<TEntity>().Remove(Select(id));
            _sqlContext.SaveChanges();
        }

        public void DeleteByCompoundKey(object[] compoundKey)
        {
            _sqlContext.Set<TEntity>().Remove(SelectByCompoundKey(compoundKey));
            _sqlContext.SaveChanges();
        }

        public IList<TEntity> Select() =>
            _sqlContext.Set<TEntity>().ToList();

        public TEntity Select(int id) =>
            _sqlContext.Set<TEntity>().Find(id);
        public TEntity SelectByCompoundKey(object[] compoundKey) =>
            _sqlContext.Set<TEntity>().Find(compoundKey);
    }
}
