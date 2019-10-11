using DomainCore.Entities;
using DomainCore.Interfaces;
using InfraCore.Context.Commands;
using InfraCore.Context.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;

namespace InfraCore.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly CommandsDbContext contextCommands = new CommandsDbContext();

        private readonly QueriesDbContext queriesCommands = new QueriesDbContext();

        public async Task AddAsync(T obj)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    await contextCommands.Set<T>().AddAsync(obj);

                    await contextCommands.SaveChangesAsync();

                    await queriesCommands.Set<T>().AddAsync(obj);

                    await queriesCommands.SaveChangesAsync();

                    ts.Complete();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task RemoveAsync(int id)
        {
            contextCommands.Set<T>().Remove(await SelectByIdAsync(id));

            await contextCommands.SaveChangesAsync();
        }

        public async Task<T> SelectByIdAsync(int id)
        {
            return await queriesCommands.Set<T>().FindAsync(id);
        }

        public async Task<IList<T>> SelectAllAsync()
        {
            return await queriesCommands.Set<T>().ToListAsync();
        }

        public async Task UpdateAsync(T obj)
        {
            contextCommands.Entry(obj).State = EntityState.Modified;

            await contextCommands.SaveChangesAsync();
        }
    }
}
