using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Projeto_gamer.Models;

namespace Projeto_gamer.Infra
{
    public class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // string de conexão com o banco
                // Data Surce: O nome do servidor do gerenciador do banco
                // initial catalog: Nome do banco de dados

                // Autentucação pelo o Windows
                // Integrated Security: Autenticação pelo o Windows
                // TrusteserverCertificate: Autentucação pelo o Windows

                // Autenticação pelo Sqlserver
                // Id User = "Nome do seu usuario de login"
                // password = "senha do seu usuario"

                optionsBuilder.UseSqlServer("Data Source = NOTE05-S14; Initial Catalog = GamerManha;     User Id = sa; pwd = Senai@134; TrustServerCertificate = true ");
            }
        }


        // referencia  
        public DbSet<Jogador> jogador { get; set; }

        public DbSet<Equipe> Equipe { get; set; }

        // public DbSet<Login> Login {get;set;}
    }

}