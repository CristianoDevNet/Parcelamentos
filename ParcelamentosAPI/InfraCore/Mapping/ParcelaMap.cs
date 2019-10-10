using DomainCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfraCore.Mapping
{
    public class ParcelaMap : IEntityTypeConfiguration<Parcela>
    {
        public void Configure(EntityTypeBuilder<Parcela> builder)
        {
            builder.ToTable("Parcela");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.OrcamentoId)
            .IsRequired()
            .HasColumnName("OrcamentoId");

            builder.Property(c => c.Valor)
            .IsRequired()
            .HasColumnName("Valor");

            builder.Property(c => c.Data)
            .IsRequired()
            .HasColumnName("Data");
        }
    }
}
