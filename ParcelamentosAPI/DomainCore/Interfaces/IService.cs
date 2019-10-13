using DomainCore.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DomainCore.Interfaces
{
    public interface IService<T> where T : BaseEntity
    {
        Task<T> PostAsync<V>(T obj) where V : AbstractValidator<T>;

        Task<T> PutAsync<V>(T obj) where V : AbstractValidator<T>;

        Task DeleteAsync(int d);

        Task<T> GetByIdAsync(int id);

        Task<IList<T>> GetAllAsync();

        Task<IList<T>> GetByConditionAsync(Expression<Func<T, bool>> expression);
    }
}
