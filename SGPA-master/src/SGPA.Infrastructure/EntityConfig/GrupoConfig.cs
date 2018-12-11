using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGPA.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;


namespace SGPA.Infrastructure.EntityConfig
{
    public class GrupoConfig : IEntityTypeConfiguration<Grupo>
    {
        public void Configure(EntityTypeBuilder<Grupo> builder)
        {
            // Configurando a entidade Grupo com Fluent API
            builder.Property(x => x.Descricao)
           .HasColumnType("varchar(30)");

        }
    }
}