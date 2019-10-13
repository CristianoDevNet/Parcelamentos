using DomainCore.Entities;
using DomainCore.Interfaces;
using InfraCore.Context.Commands;
using InfraCore.Context.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Transactions;

namespace InfraCore.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly CommandsDbContext contextCommands = new CommandsDbContext();

        private readonly QueriesDbContext contextQueries = new QueriesDbContext();

        private int retorno;

        private readonly string erroSalvarBaseReplicacao = "Não foi possível salvar na base de replicação";

        private readonly string erroRemoverBaseReplicacao = "Não foi possível remover da base de replicação";

        private readonly string erroAtualizarBaseReplicacao = "Não foi possível atualizar a base de replicação";

        public async Task AddAsync(T obj)
        {
            try
            {
                await contextCommands.Set<T>().AddAsync(obj);

                retorno = await contextCommands.SaveChangesAsync();

                if(retorno > 0)
                {
                    await contextQueries.Set<T>().AddAsync(obj);

                    retorno = await contextQueries.SaveChangesAsync();

                    if(retorno < 1)
                    {
                        await RemoveAsync(obj.Id);

                        throw new Exception(erroSalvarBaseReplicacao);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                contextCommands.Set<T>().Remove(await SelectByIdAsync(id));

                retorno = await contextCommands.SaveChangesAsync();

                if (retorno > 0)
                {
                    contextQueries.Set<T>().Remove(await SelectByIdAsync(id));

                    retorno = await contextQueries.SaveChangesAsync();

                    if (retorno < 1)
                    {
                        throw new Exception(erroRemoverBaseReplicacao);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> SelectByIdAsync(int id)
        {
            return await contextQueries.Set<T>().FindAsync(id);
        }

        public async Task<IList<T>> SelectAllAsync()
        {
            return await contextQueries.Set<T>().ToListAsync();
        }

        //public async Task UpdateAsync(T obj)
        //{
        //    throw new NotImplementedException();

        //    //try
        //    //{
        //    //    contextCommands.Entry(obj).State = EntityState.Modified;

        //    //    retorno = await contextCommands.SaveChangesAsync();

        //    //    if (retorno > 0)
        //    //    {
        //    //        contextQueries.Entry(obj).State = EntityState.Modified;

        //    //        retorno = await contextQueries.SaveChangesAsync();

        //    //        if (retorno < 1)
        //    //        {
        //    //            throw new Exception(erroAtualizarBaseReplicacao);
        //    //        }
        //    //    }
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    throw ex;
        //    //}
        //}

        //public async Task<IList<T>> GetByCondition(Expression<Func<T, bool>> expression)
        //{
        //    return await contextQueries.Set<T>().Where(expression).AsNoTracking().ToListAsync();
        //}
        
        public Task UpdateAsync(T obj)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression)
        {
            return contextQueries.Set<T>().Where(expression).AsNoTracking();
        }
    }
}
