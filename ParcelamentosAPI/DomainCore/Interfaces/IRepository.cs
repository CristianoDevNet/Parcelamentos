using DomainCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DomainCore.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task AddAsync(T obj);

        Task UpdateAsync(T obj);

        Task RemoveAsync(int id);

        Task<T> SelectByIdAsync(int id);

        Task<IList<T>> SelectAllAsync();

        IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression);
    }
}
