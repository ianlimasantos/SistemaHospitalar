using Cadastro.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Infra.Data.EF.Maps
{
    public class PacienteMapping : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CartaoSUS)
                .IsRequired();

            builder.Property(x => x.Telefone)
                .IsRequired();

            builder.Property(x => x.Validade_Cartao)
                .IsRequired();
            
            builder.Property(x => x.DataCadastro)
                .IsRequired();

            builder.Property(x => x.DataUpdate)
                .IsRequired();

            builder.Property(x => x.Ativo)
                .IsRequired();

            builder.HasOne(x => x.Pessoa)
                .WithOne(x => x.Paciente)
                .HasForeignKey<Paciente>(x => x.PessoaId);
        }
    }
}
