using Microsoft.EntityFrameworkCore;
using Cadastro.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cadastro.Infra.Data.EF.Maps
{
    public class ConsultaMapping : IEntityTypeConfiguration<Consulta>
    {
        public void Configure(EntityTypeBuilder<Consulta> builder)
        {
            builder.HasKey(x => x.Id);
   
            builder.Property(x => x.MedicoId)
                .HasColumnName("MedicoId")
                .IsRequired();

            builder.Property(x => x.PacienteId)
                .HasColumnName("PacienteId")
                .IsRequired();

            builder.Property(x => x.DataInicio)
                .IsRequired();

            builder.Property(x => x.DataCadastro)
                .IsRequired();

            builder.Property(x => x.DataUpdate);

            builder.Property(x => x.Ativo)
                .IsRequired();

            builder.Property(x => x.MotivoCancelamento)
                .IsRequired();

            builder.HasOne(x => x.Medico)
                .WithMany(x => x.Consultas)
                .HasForeignKey(x => x.MedicoId);

            builder.HasOne(x => x.Paciente)
                .WithMany(x => x.Consultas)
                .HasForeignKey(x => x.PacienteId);
        }
    }
}
