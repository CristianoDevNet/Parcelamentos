using DomainCore.Entities;
using InfraCore.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfraCore.Context.Commands
{
    public class CommandsDbContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Orcamento> Orcamentos { get; set; }

        public DbSet<Parcela> Parcelas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("Server=csd0201wnt47f;Initial Catalog=teste;User Id=teste;Password=t3st3;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Produto>(new ProdutoMap().Configure);

            modelBuilder.Entity<Orcamento>(new OrcamentoMap().Configure);

            modelBuilder.Entity<Parcela>(new ParcelaMap().Configure);
        }
    }
}
