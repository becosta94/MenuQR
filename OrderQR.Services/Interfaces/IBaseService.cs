using FluentValidation;
using OrderQR.Domain.Entities;

namespace OrderQR.Services.Interfaces
{
    public interface IBaseService<TEntity> where TEntity : BaseEntity
    {
        TEntity Add<TValidator>(TEntity obj, int companyId, string userId) where TValidator : AbstractValidator<TEntity>;
        void Delete(int id, int companyId, string userId);
        void DeleteByCompoundKey(object[] compoundKey, int companyId, string userId);
        TEntity Update<TValidator>(TEntity obj, int companyId, string userId) where TValidator : AbstractValidator<TEntity>;
        IList<TEntity> Get();
        TEntity GetById(int id);
        TEntity GetByCompoundKey(object[] compoundKey);
    }
}
