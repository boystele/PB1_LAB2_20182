using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGPA.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;


namespace SGPA.Infrastructure.EntityConfig
{
    public class ClienteConfig : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            // Configurando a entidade Cliente com Fluent API
            builder.Property(x => x.Descricao)
           .HasColumnType("varchar(30)");

            builder.Property(x => x.Email)
           .HasColumnType("varchar(30)");


        }
    }
}