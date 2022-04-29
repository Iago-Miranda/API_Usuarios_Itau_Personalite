using Entidades.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestrutura.Configuracoes
{
    public class ContextoUsuariosPersonalite : DbContext
    {
        public ContextoUsuariosPersonalite(DbContextOptions<ContextoUsuariosPersonalite> opcoes) : base(opcoes)
        {
            this.Database.EnsureCreated();
            this.Database.Migrate();
        }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ObterStringConexao());
                base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    Id = 1,
                    Nome = "Administrador",
                    Email = "Administrador@itau.personalite.com.br",
                    Senha = "JRSznD]8P<*R"
                }
            );

            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.Email)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }

        public string ObterStringConexao()
        {
            string strcon = "Server=localhost;Database=Usuarios_Personalite;Trusted_Connection=True;";
            return strcon;
        }
    }
}
