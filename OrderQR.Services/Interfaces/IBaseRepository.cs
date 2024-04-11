using OrderQR.Domain.Entities;

namespace OrderQR.Services.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        void Insert(TEntity obj);
        void Update(TEntity obj);
        void Delete(int id);
        void DeleteByCompoundKey(object[] compoundKey);
        IList<TEntity> Select();
        TEntity Select(int id);
        TEntity SelectByCompoundKey(object[] compoundKey);
    }
}
