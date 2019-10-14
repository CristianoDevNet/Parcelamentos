using DomainCore.Entities;
using DomainCore.Interfaces;
using FluentValidation;
using InfraCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            if(obj.GetType() == typeof(Produto))
            {
                obj = GerarParcelas(obj as Produto);
            }

            Validate(obj, Activator.CreateInstance<V>());

            await repository.AddAsync(obj);
            
            return obj;
        }

        public async Task<T> PutAsync<V>(T obj) where V : AbstractValidator<T>
        {
            throw new NotImplementedException();

            //Validate(obj, Activator.CreateInstance<V>());

            //await repository.UpdateAsync(obj);

            //return obj;
        }

        private T GerarParcelas(Produto produto)
        {
            Orcamento orcamento = produto.Orcamentos.FirstOrDefault();

            decimal valorParcelaComJuros = (decimal)Math.Round(Financial.Pmt((double)(orcamento.JurosMes / 100), orcamento.QtdParcelas, (double)orcamento.ValorBase), 2);

            ICollection<Parcela> parcelas = new List<Parcela>();

            for (int i = 0; i < orcamento.QtdParcelas; i++)
            {
                parcelas.Add(new Parcela
                {
                    Valor = -valorParcelaComJuros,
                    Data = orcamento.PrimeiroVencimento.AddMonths(i)
                });
            }

            produto.Orcamentos.FirstOrDefault().Parcelas = parcelas;
            
            return produto as T;
        }

        public async Task<IList<T>> GetByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return await repository.GetByCondition(expression).ToListAsync();
        }

        //public async Task<IList<T>> GetByConditionAsync(Expression<Func<T, bool>> expression)
        //{
        //    return await repository.GetByCondition(expression);
        //}
    }
}
