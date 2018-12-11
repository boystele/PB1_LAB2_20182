using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGPA.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;


namespace SGPA.Infrastructure.EntityConfig
{
    public class VooConfig : IEntityTypeConfiguration<Voo>
    {
        public void Configure(EntityTypeBuilder<Voo> builder)
        {
            // Configurando a entidade Voo com Fluent API
            builder.Property(x => x.Descricao)
           .HasColumnType("varchar(30)");

        }
    }
}