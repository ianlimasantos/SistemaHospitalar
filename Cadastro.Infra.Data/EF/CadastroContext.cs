using Cadastro.Domain.Interfaces;
using Cadastro.Domain.Models;
using Cadastro.Infra.Data.EF.Maps;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace Cadastro.Infra.Data.EF
{
    public class CadastroContext : DbContext, IUnitOfWork
    {
        public CadastroContext(DbContextOptions options) : base(options) 
        {
            ChangeTracker.LazyLoadingEnabled = false;

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.LogTo(Console.WriteLine);


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PessoaMapping());
            modelBuilder.ApplyConfiguration(new MedicoMapping());
            modelBuilder.ApplyConfiguration(new PacienteMapping());
            modelBuilder.ApplyConfiguration(new ConsultaMapping());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<EnderecoConsultorio> EnderecoConsultorios { get; set; }
    }
}
