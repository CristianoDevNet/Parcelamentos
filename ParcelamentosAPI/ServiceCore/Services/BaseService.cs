using DomainCore.Entities;
using DomainCore.Interfaces;
using FluentValidation;
using InfraCore.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCore.Services
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {
        private readonly BaseRepository<T> repository = new BaseRepository<T>();

        private readonly string idZero = "O Id não pode ser ZERO.";

        private void Validate(T obj, AbstractValidator<T> validator)
        {
            if (obj == null)
                throw new Exception("Registros não encontrados!");

            validator.ValidateAndThrow(obj);
        }

        public async Task DeleteAsync(int id)
        {
            if (id == 0)
                throw new ArgumentException(idZero);

            await repository.RemoveAsync(id);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            if (id == 0)
                throw new ArgumentException(idZero);

            return await repository.SelectByIdAsync(id);
        }

        public async Task<IList<T>> GetAllAsync()
        {
            return await repository.SelectAllAsync();
        }

        public async Task<T> PostAsync<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            await repository.AddAsync(obj);
            
            return obj;
        }

        public async Task<T> PutAsync<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            await repository.UpdateAsync(obj);

            return obj;
        }
    }
}
