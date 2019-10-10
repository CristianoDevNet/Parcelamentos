using DomainCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfraCore.Mapping
{
    public class OrcamentoMap : IEntityTypeConfiguration<Orcamento>
    {
        public void Configure(EntityTypeBuilder<Orcamento> builder)
        {
            builder.ToTable("Orcamento");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.ProdutoId)
            .IsRequired()
            .HasColumnName("ProdutoId");

            builder.Property(c => c.ValorBase)
            .IsRequired()
            .HasColumnName("ValorBase");

            builder.Property(c => c.JurosMes)
            .IsRequired()
            .HasColumnName("JurosMes");
        }
    }
}
