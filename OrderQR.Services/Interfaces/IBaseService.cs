using FluentValidation;
using OrderQR.Domain.Entities;

namespace OrderQR.Services.Interfaces
{
    public interface IBaseService<TEntity> where TEntity : BaseEntity
    {
        TEntity Add<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>;
        void Delete(int id);
        void DeleteByCompoundKey(object[] compoundKey);
        IList<TEntity> Get();
        TEntity GetById(int id);
        TEntity GetByCompoundKey(object[] compoundKey);
        TEntity Update<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>;
    }
}
