using OrderQR.Domain.Entities;
using OrderQR.Infra.Data.Context;
using OrderQR.Services.Interfaces;

namespace OrderQR.Infra.Data.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly SqlContext _sqlContext;

        public BaseRepository(SqlContext mySqlContext)
        {
            _sqlContext = mySqlContext;
        }

        public void Insert(TEntity obj, int companyId, string userId)
        {
            _sqlContext.Set<TEntity>().Add(obj);
            _sqlContext.SaveChanges(companyId, userId);
        }

        public void Update(TEntity obj, int companyId, string userId)
        {
            _sqlContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _sqlContext.SaveChanges(companyId, userId);
        }
        public void Delete(int id, int companyId, string userId)
        {
            _sqlContext.Set<TEntity>().Remove(Select(id));
            _sqlContext.SaveChanges(companyId, userId);
        }

        public void DeleteByCompoundKey(object[] compoundKey, int companyId, string userId)
        {
            _sqlContext.Set<TEntity>().Remove(SelectByCompoundKey(compoundKey));
            _sqlContext.SaveChanges(companyId, userId);
        }

        public IList<TEntity> Select() =>
            _sqlContext.Set<TEntity>().ToList();

        public TEntity Select(int id) =>
            _sqlContext.Set<TEntity>().Find(id);
        public TEntity SelectByCompoundKey(object[] compoundKey) =>
            _sqlContext.Set<TEntity>().Find(compoundKey);
    }
}
