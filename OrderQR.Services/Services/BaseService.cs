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

        public TEntity Add<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>
        {
            Validate(obj, Activator.CreateInstance<TValidator>());
            _baseRepository.Insert(obj);
            return obj;
        }

        public void Delete(int id) => _baseRepository.Delete(id);
        public void DeleteByCompoundKey(object[] compoundKey) => _baseRepository.DeleteByCompoundKey(compoundKey);

        public IList<TEntity> Get() => _baseRepository.Select();

        public TEntity GetById(int id) => _baseRepository.Select(id);
        public TEntity GetByCompoundKey(object[] compoundKey) => _baseRepository.SelectByCompoundKey(compoundKey);

        public TEntity Update<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>
        {
            Validate(obj, Activator.CreateInstance<TValidator>());
            _baseRepository.Update(obj);
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
