using Microsoft.EntityFrameworkCore;
using SGPA.ApplicationCore;
using SGPA.ApplicationCore.Entity;
using SGPA.Infrastructure.EntityConfig;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGPA.Infrastructure.Data
{
    public class SGPAContext : DbContext
    {

        public SGPAContext()
        {


        }

        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Passagem> Passagens { get; set; }
        public DbSet<Voo> Voos { get; set; }
        public DbSet<PassagemAerea> PassagensAereas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=BdSGPA;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            #region propagação de dados das entidades

                 modelBuilder.Entity<PassagemAerea>()
                .HasKey(ch => new { ch.PassagemId, ch.GrupoId });

                 modelBuilder.Entity<Cliente>()
                .HasData(

                new Cliente { ClienteId = 1, Descricao = "Robson", Email = "Robsonrodrigues_12@hotmail.com" },
                new Cliente { ClienteId = 2, Descricao = "Neemias", Email = "NeemiasFernandes@hotmail.com" }
                );

                 modelBuilder.Entity<Voo>()
                .HasData(

                new Voo { VooId = 1, Descricao = "Rio Janeiro", Numero = 10},
                new Voo { VooId = 2, Descricao = "Sao Paulo", Numero = 24}
                );

                 modelBuilder.Entity<Grupo>()
                .HasData(

                new Grupo { GrupoId = 1, Descricao = "Sei la"},
                new Grupo { GrupoId = 2, Descricao = "Eu Adoro"}
                );

                 modelBuilder.Entity<Passagem>()
                .HasData(

                    new Passagem { PassagemId = 1, Valor = 100, DataEmissao = System.DateTime.Today, ClienteId = 1 },
                    new Passagem { PassagemId = 2, Valor = 500, DataEmissao = System.DateTime.Today, ClienteId = 2}

                );

                 modelBuilder.Entity<Endereco>()
                .HasData(

                new Endereco { EnderecoId = 1, Logradouro = "Cuiaba", Bairro = "Dr Fabio", CEP = "55555555", Numero = "1896", ClienteId = 1 },
                new Endereco { EnderecoId = 2, Logradouro = "Cuiaba-Alphaville", Bairro = "Jardim Itália", CEP = "88888888", Numero = "2424", ClienteId = 2 }
                );

            #endregion

            modelBuilder.ApplyConfiguration(new ClienteConfig());
            modelBuilder.ApplyConfiguration(new VooConfig());
            modelBuilder.ApplyConfiguration(new GrupoConfig());
            modelBuilder.ApplyConfiguration(new EndereConfig());
        }
    }
}