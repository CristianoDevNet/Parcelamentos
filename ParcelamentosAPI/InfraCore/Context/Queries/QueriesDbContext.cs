using DomainCore.Entities;
using InfraCore.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace InfraCore.Context.Queries
{
    class QueriesDbContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Orcamento> Orcamentos { get; set; }

        public DbSet<Parcela> Parcelas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlite($"Data Source=Queries.db");
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
