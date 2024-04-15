using FluentValidation;
using OrderQR.Domain.Entities;
using OrderQR.Services.Interfaces;

namespace OrderQR.Services.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        private readonly IBaseRepository<TEntity> _baseRepository;

        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public TEntity Add<TValidator>(TEntity obj, int companyId, string userId) where TValidator : AbstractValidator<TEntity>
        {
            Validate(obj, Activator.CreateInstance<TValidator>());
            _baseRepository.Insert(obj, companyId, userId);
            return obj;
        }

        public void Delete(int id, int companyId, string userId) => _baseRepository.Delete(id, companyId, userId);
        public void DeleteByCompoundKey(object[] compoundKey, int companyId, string userId) => _baseRepository.DeleteByCompoundKey(compoundKey, companyId, userId);

        public IList<TEntity> Get() => _baseRepository.Select();

        public TEntity GetById(int id) => _baseRepository.Select(id);
        public TEntity GetByCompoundKey(object[] compoundKey) => _baseRepository.SelectByCompoundKey(compoundKey);

        public TEntity Update<TValidator>(TEntity obj, int companyId, string userId) where TValidator : AbstractValidator<TEntity>
        {
            Validate(obj, Activator.CreateInstance<TValidator>());
            _baseRepository.Update(obj, companyId, userId);
            return obj;
        }
        private void Validate(TEntity obj, AbstractValidator<TEntity> validator)
        {
            if (obj == null)
                throw new Exception("Registros não detectados!");

            validator.ValidateAndThrow(obj);
        }
    }
}
