using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Juntos.Model;

namespace Juntos.DAL.Provider.EntityFramework
{
    internal class JuntosContext : DbContext
    {
        private static JuntosContext _instance;

        private JuntosContext(string connectionString) : base(connectionString)
        {
        }

        public static JuntosContext Instance
        {
            get
            {
                _instance = _instance ?? new JuntosContext("JuntosDb");
                return _instance;
            }
        }

        public DbSet<Anunciante> Anunciantes { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Consumidor> Consumidores { get; set; }
        public DbSet<Cupom> Cupons { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Oferta> Ofertas { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Telefone> Telefones { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Chaves Primarias e como sao geradas
            modelBuilder.Entity<Pessoa>().HasKey(c => c.Id);
            modelBuilder.Entity<Pessoa>().Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Endereco>().HasKey(e => e.Id);
            modelBuilder.Entity<Endereco>().Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Telefone>().HasKey(e => e.Id);
            modelBuilder.Entity<Telefone>().Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Oferta>().HasKey(e => e.Id);
            modelBuilder.Entity<Oferta>().Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            
            modelBuilder.Entity<Cupom>().HasKey(e => e.Id);
            modelBuilder.Entity<Cupom>().Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Compra>().HasKey(e => e.Id);
            modelBuilder.Entity<Compra>().Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            
            modelBuilder.Entity<Pagamento>().HasKey(e => e.Id);
            modelBuilder.Entity<Pagamento>().Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //Relacionamentos 1:n
            modelBuilder.Entity<Pessoa>().HasMany(e => e.Enderecos);
            modelBuilder.Entity<Pessoa>().HasMany(e => e.Telefones);

            modelBuilder.Entity<Anunciante>().HasMany(e => e.Ofertas);
            modelBuilder.Entity<Consumidor>().HasMany(e => e.Compras);

            modelBuilder.Entity<Oferta>().HasMany(e => e.CuponsGerados);

            modelBuilder.Entity<Compra>().HasMany(e => e.Cupons);
            modelBuilder.Entity<Compra>().HasMany(e => e.Pagamentos);

            base.OnModelCreating(modelBuilder);
        }
    }
}
