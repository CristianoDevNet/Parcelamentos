using DomainCore.Entities;
using DomainCore.Interfaces;
using InfraCore.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraCore.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext context = new AppDbContext();

        public async Task AddAsync(T obj)
        {
            await context.Set<T>().AddAsync(obj);
            await context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            context.Set<T>().Remove(await SelectByIdAsync(id));
            await context.SaveChangesAsync();
        }

        public async Task<T> SelectByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<IList<T>> SelectAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task UpdateAsync(T obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
