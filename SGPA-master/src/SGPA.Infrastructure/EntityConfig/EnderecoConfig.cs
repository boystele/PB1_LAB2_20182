using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGPA.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;


namespace SGPA.Infrastructure.EntityConfig
{
    public class EndereConfig : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            // Configurando a entidade Endereco com Fluent API
            builder.Property(x => x.Logradouro)
           .HasColumnType("varchar(100)");

            builder.Property(x => x.Bairro)
           .HasColumnType("varchar(100)");

            builder.Property(x => x.CEP)
           .HasColumnType("varchar(8)");

            builder.Property(x => x.Numero)
           .HasColumnType("varchar(4)");

        }
    }
}