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
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-DJAK16E;Initial Catalog=Commands;integrated security=True;multipleactiveresultsets=True");
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
