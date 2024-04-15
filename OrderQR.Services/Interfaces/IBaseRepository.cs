using OrderQR.Domain.Entities;

namespace OrderQR.Services.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        void Insert(TEntity obj, int companyId, string userId);
        void Update(TEntity obj, int companyId, string userId);
        void Delete(int id, int companyId, string userId);
        void DeleteByCompoundKey(object[] compoundKey, int companyId, string userId);
        IList<TEntity> Select();
        TEntity Select(int id);
        TEntity SelectByCompoundKey(object[] compoundKey);
    }
}
