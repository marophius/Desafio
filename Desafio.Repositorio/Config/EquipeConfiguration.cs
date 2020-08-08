using Desafio.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Repositorio.Config
{
    public class EquipeConfiguration : IEntityTypeConfiguration<Equipe>
    {
        public void Configure(EntityTypeBuilder<Equipe> builder)
        {
            builder.HasKey(eq => eq.Id);
            builder.Property(eq => eq.NomeEquipe)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(eq => eq.NomeGestor)
                .IsRequired()
                .HasMaxLength(100);
            builder.HasMany(eq => eq.Colaboradores).WithOne(c => c.Equipe);
        }
    }
}
