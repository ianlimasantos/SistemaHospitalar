using Cadastro.Domain.Interfaces;
using Cadastro.Domain.Models;
using Cadastro.Infra.Data.EF.Maps;
using Microsoft.EntityFrameworkCore;

namespace Cadastro.Infra.Data
{
    public class CadastroContext : DbContext, IUnitOfWork
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PessoaMapping());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Pessoa> Pessoas { get; set; }
    }
}
